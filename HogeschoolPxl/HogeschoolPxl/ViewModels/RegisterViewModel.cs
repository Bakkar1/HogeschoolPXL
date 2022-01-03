using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confrim password")]
        [Compare("Password",
            ErrorMessage = "Password and confimation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string RoleId { get; set; }
    }
}
