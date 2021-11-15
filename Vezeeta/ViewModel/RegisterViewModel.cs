using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vezeeta.Models;

namespace Vezeeta.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "الاسم")]

        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "الايميل")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمة المرور وتاكيد كلمة المرور غير متطابقان")]
        public string ConfirmPassword { get; set; }
       
       

    }
}