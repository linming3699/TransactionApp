using System.ComponentModel.DataAnnotations;

namespace Transcation_app.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "請輸入電子信箱!")]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
        [Required(ErrorMessage = "請輸入密碼!")]
        [Display(Name = "密碼")]
        public string Password { get; set; }
    }
    public class SignUpDto
    {
        [Required(ErrorMessage = "請輸入電子信箱!")]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
        [Required(ErrorMessage = "請輸入密碼!")]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Required(ErrorMessage = "請輸入使用者名稱!")]
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }
    }
}
