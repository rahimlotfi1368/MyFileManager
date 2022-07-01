using System.ComponentModel.DataAnnotations;

namespace MaadiranChainStorePrices.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Messages.RequiredMesg), 
            ErrorMessageResourceType = typeof(Resources.Messages),
            AllowEmptyStrings = false)]

        [Display(Name = nameof(Resources.DataDictionary.UserName),
            ResourceType = typeof(Resources.DataDictionary))]

        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Messages.RequiredMesg),
           ErrorMessageResourceType = typeof(Resources.Messages),
           AllowEmptyStrings = false)]

        [Display(Name = nameof(Resources.DataDictionary.Password),
           ResourceType = typeof(Resources.DataDictionary))]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = nameof(Resources.DataDictionary.UserName),
            ResourceType = typeof(Resources.DataDictionary))]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
