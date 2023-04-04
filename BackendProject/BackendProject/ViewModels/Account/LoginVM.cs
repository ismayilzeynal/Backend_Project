using System.ComponentModel.DataAnnotations;

namespace BackendProject.ViewModels.Account
{
    public class LoginVM
    {
        [Required, StringLength(100)]
        public string UsernameOrEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
