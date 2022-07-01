using MaadiranChainStorePrices.Attribute;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MaadiranChainStorePrices.ViewModels
{
    public class AddBrandViewModel
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Messages.RequiredMesg),
            ErrorMessageResourceType = typeof(Resources.Messages),
            AllowEmptyStrings = false)]

        [Display(Name = nameof(Resources.DataDictionary.BrandName),
            ResourceType = typeof(Resources.DataDictionary))]
        public string BrandName { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Messages.RequiredMesg),
            ErrorMessageResourceType = typeof(Resources.Messages),
            AllowEmptyStrings = false)]

        [Display(Name = nameof(Resources.DataDictionary.BrandLogo),
            ResourceType = typeof(Resources.DataDictionary))]

        [AllowFileSize(FileSize = 1 * 1024 * 1024,
            ErrorMessageResourceName = nameof(Resources.Messages.InvalidFileSize), 
            ErrorMessageResourceType = typeof(Resources.Messages))]

        [AllowedExtensions(new string[] { ".png" })]
        public IFormFile BrandLogo { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Messages.RequiredMesg),
            ErrorMessageResourceType = typeof(Resources.Messages),
            AllowEmptyStrings = false)]

        [Display(Name = nameof(Resources.DataDictionary.BrandKatalog),
            ResourceType = typeof(Resources.DataDictionary))]

        [AllowFileSize(FileSize = 1 * 1024 * 1024,
            ErrorMessageResourceName = nameof(Resources.Messages.InvalidFileSize),
            ErrorMessageResourceType = typeof(Resources.Messages))]

        [AllowedExtensions(new string[] { ".pdf" })]
        public IFormFile BrandKatalog { get; set; }
    }
}
