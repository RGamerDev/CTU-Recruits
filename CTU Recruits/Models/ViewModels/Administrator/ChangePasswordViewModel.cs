using System.ComponentModel.DataAnnotations;

namespace CTU_Recruits.Models.ViewModels.Administrator
{
    public class ChangePasswordViewModel
    {
        public string id { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password does not match"),
            DataType(DataType.Password), Display(Name = "Confirm new Password")]
        public string ConfirmPassword { get; set; }
    }
}
