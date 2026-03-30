using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPOO2.Models
{
    public class Item1
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Display(Name = "Descripción")]
        public string desc { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Valor")]
        public decimal n1 { get; set; }

        [Display(Name = "Disponible")]
        public bool IsAvailable { get; set; }
    }
}
