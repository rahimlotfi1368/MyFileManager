using MaadiranChainStorePrices.Models.Entities;
using MaadiranChainStorePrices.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MaadiranChainStorePrices.Dal.Repository
{
    public interface IAdminRepository
    {
        Task<User> GetUserByUserNameAysnc(string userName);
        Task<bool> LoginAysnc(LoginViewModel viewModel);
        Task<bool> CreateNewBrandAysnc(AddBrandViewModel viewModel);
        string UploadFile(IFormFile file , string brandName );
        Task<bool> LogOutAysnc();
    }
}
