using System.ComponentModel.DataAnnotations;

namespace PPOO2.Models.ViewModels
{
    public class ListPost1
    {
        public int id { get; set; }

        [Display(Name = "Título")]
        public string title { get; set; }

        [Display(Name = "Artista")]
        public string artist { get; set; }

        [Display(Name = "Género")]
        public string genre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de lanzamiento")]
        public DateTime? release_date { get; set; }

        [Display(Name = "Subido por")]
        public string uploader { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de subida")]
        public DateTime upload_date { get; set; }

        [Display(Name = "Aprobado")]
        public bool approbation { get; set; }
    }
}
