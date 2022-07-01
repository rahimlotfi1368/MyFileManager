using MaadiranChainStorePrices.Dal.Repository;
using MaadiranChainStorePrices.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaadiranChainStorePrices.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _repository;

        public AdminController(IAdminRepository repository) :base()
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl=null)
        {
            _repository.LogOutAysnc();
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var loginResult =await _repository.LoginAysnc(viewModel);

                if(loginResult )
                {
                    if (viewModel.ReturnUrl != null)
                    {
                        return RedirectToAction(viewModel.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(AdminPanel));
                    }
                }

            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _repository.LogOutAysnc();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewBrand()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>  AddNewBrand(AddBrandViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result =await _repository.CreateNewBrandAysnc(viewModel);

                if (result) return RedirectToAction(nameof(AdminPanel));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
