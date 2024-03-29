﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMSSystem.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    //public class ValidationViewModel
    //{
    //    [Display(Name = "Email address")]
    //    [Required(ErrorMessage = "The email address is required")]
    //    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    //    public string Email { get; set; }
    //}
}