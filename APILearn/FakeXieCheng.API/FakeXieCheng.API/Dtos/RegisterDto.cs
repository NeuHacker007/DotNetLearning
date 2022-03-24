using System.ComponentModel.DataAnnotations;

namespace FakeXieCheng.API.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email 必填")]
        [EmailAddress(ErrorMessage = "Email 地址不合法")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password 必填")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password 必填")]
        [Compare(nameof(Password), ErrorMessage = "两次密码必须一致")]
        public string ConfirmPassword { get; set; }
    }
}
