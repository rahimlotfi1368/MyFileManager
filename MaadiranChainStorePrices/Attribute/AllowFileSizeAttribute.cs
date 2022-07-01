using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace MaadiranChainStorePrices.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowFileSizeAttribute: ValidationAttribute
    {
        public int FileSize { get; set; } //= 2 * 1024 * 1024;
        public override bool IsValid(object value)
        {
            IFormFile formFile = value as IFormFile;

            bool isValid = true;

            int allowedFileSize = this.FileSize;

            if (formFile != null)
            {
                // Initialization.  
                var fileSize = formFile.Length;

                // Settings.  
                isValid = fileSize <= allowedFileSize;
            }

            // Info  
            return isValid;

        }
    }
}
