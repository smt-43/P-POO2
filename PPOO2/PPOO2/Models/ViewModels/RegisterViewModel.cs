using System.ComponentModel.DataAnnotations;

namespace PPOO2.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio."),
        EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria."),
        MinLength(6, ErrorMessage = "La contraseña debe ser de 6 caracteres o menos.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }
    }
}
