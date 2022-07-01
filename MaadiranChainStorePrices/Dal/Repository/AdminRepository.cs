using MaadiranChainStorePrices.Helper;
using MaadiranChainStorePrices.Models.Entities;
using MaadiranChainStorePrices.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaadiranChainStorePrices.Dal.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminRepository(DataBaseContext dataBaseContext, IHttpContextAccessor contextAccessor, IWebHostEnvironment hostEnvironment )
        {
            DataBaseContext = dataBaseContext;
            _contextAccessor = contextAccessor;
            _hostEnvironment = hostEnvironment;
        }

        public DataBaseContext DataBaseContext { get; }

        public async Task<bool> CreateNewBrandAysnc(AddBrandViewModel viewModel)
        {
            try
            {
                var logoName=UploadFile(viewModel.BrandLogo,viewModel.BrandName);

                var katalog=UploadFile(viewModel.BrandKatalog,viewModel.BrandName);

                DataBaseContext.Brands.Add(new Brand
                {
                    BrandName = viewModel.BrandName,
                    LogoName= logoName,
                    KatalogName= katalog
                });

                await DataBaseContext.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<User> GetUserByUserNameAysnc(string userName)
        {
            var foundedUser=await DataBaseContext.Users.FirstOrDefaultAsync(x=>x.UserName.ToLower() == userName.ToLower());
            return foundedUser;
        }

        public async Task<bool> LoginAysnc(LoginViewModel viewModel)
        {
            try
            {


                var foundedUser = await GetUserByUserNameAysnc(viewModel.UserName);

                if (foundedUser == null) return false;

                if (!BCrypt.Net.BCrypt.Verify(viewModel.Password, foundedUser.Password)) return false;

                var claims = new List<Claim>();

                claims.Add(new Claim("FullName", foundedUser.FullName));

                claims.Add(new Claim(ClaimTypes.Name, viewModel.UserName));

                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                var claimsIdentity = new ClaimsIdentity(claims, Utilities.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                var authenticationProperties = new AuthenticationProperties
                {
                    IsPersistent = viewModel.RememberMe,
                };

                await _contextAccessor.HttpContext.SignInAsync(Utilities.AuthenticationScheme, claimsPrincipal, authenticationProperties);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> LogOutAysnc()
        {
            try
            {
                await _contextAccessor.HttpContext.SignOutAsync(Utilities.AuthenticationScheme);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string UploadFile(IFormFile file , string brandName)
        {
            var uploadFolder = string.Empty;

            string fileName = string.Empty;

            if (file !=null)
            {
                var fileExtention=Path.GetExtension(file.FileName);
                              
                switch (fileExtention)
                {
                    case ".pdf":
                        uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "KataLogs");
                        fileName = $"{brandName}_KataLog{fileExtention}";
                        break;
                    case ".png":
                        uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                        fileName = $"{brandName}_Logo{fileExtention}";
                        break;
                    default:
                        break;
                }

                var filePath=Path.Combine(uploadFolder, fileName);

                using (var fileStream=new FileStream(filePath,FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}
