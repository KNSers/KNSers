using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Handle_KNSER.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống.")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        
        [StringLength(100, ErrorMessage = "Mật khẩu phải từ {2} ký tự trở lên.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }


}