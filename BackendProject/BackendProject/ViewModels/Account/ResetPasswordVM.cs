﻿using System.ComponentModel.DataAnnotations;

namespace BackendProject.ViewModels.Account
{
    public class ResetPasswordVM
    {
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
