using System.ComponentModel.DataAnnotations;

namespace HomeworksOne.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ad Alanı zorunlu alandır")]
        [StringLength(20, ErrorMessage = "20 Karakterden Büyük Olamaz.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadı Alanı Zorunlu Alandır")]
        [StringLength(20, ErrorMessage = "20 Karakterden Büyük Olamaz.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Alanı Zorunlu Alandır")]
        [StringLength(50, ErrorMessage = "50 Karakterden Büyük Olamaz.")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "E-posta gereklidir ve uygun şekilde biçimlendirilmelidir.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Zorunlu Alandır")]
        [StringLength(8, ErrorMessage = "8 Karakterden Büyük Olamaz.")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$",
        ErrorMessage = "Şifreniz Büyük Harf ve Rakamlar İçermelidir")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
