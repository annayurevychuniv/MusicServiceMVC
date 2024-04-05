using System.ComponentModel.DataAnnotations;

namespace MusicServiceInfrastructure.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Пошта")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[-\w.]+@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,4}$", ErrorMessage = "Некоректний Email. Формат: example@domain.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$", ErrorMessage = "Пароль повинен містити принаймні 1 малу літеру, 1 велику літеру, 1 цифру і 1 спеціальний символ; мінімальна довжина: 6 символів")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтвердження паролю")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}