using System.ComponentModel.DataAnnotations;

namespace Evention.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunluðunda olmalý.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Þifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Þifre Tekrar")]
        [Compare("Password", ErrorMessage = "Þifre ve Þifre Tekrarý Uyuþmuyor.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}