﻿using System.ComponentModel.DataAnnotations;

namespace Session1112Identity.Models
{
    public class SignIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool rememberMe { get; set; }
    }
}
