using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        public string Password { get; set; }
    }
}
