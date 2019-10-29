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
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunlu�unda olmal�.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "�ifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "�ifre Tekrar")]
        [Compare("Password", ErrorMessage = "�ifre ve �ifre Tekrar� Uyu�muyor.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}