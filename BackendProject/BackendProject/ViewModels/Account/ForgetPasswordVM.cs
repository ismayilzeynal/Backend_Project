using System.ComponentModel.DataAnnotations;

namespace BackendProject.ViewModels.Account
{
    public class ForgetPasswordVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
