using System.ComponentModel.DataAnnotations;

namespace PPOO2.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio."),
        EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria."),
        MinLength(6, ErrorMessage = "La contraseña debe ser de 6 caracteres o menos.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
