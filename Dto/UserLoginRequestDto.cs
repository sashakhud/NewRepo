﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class UserLoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
