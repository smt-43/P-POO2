using System.ComponentModel.DataAnnotations;

namespace PPOO2.Models
{
    public class Post1
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Es Obligatorio ponerle el Título.")]
        public string title { get; set; }
        public string artist { get; set; }
        public string genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime? release_date { get; set; }
        public string url { get; set; }
        public string uploader { get; set; }
        public string description { get; set; }

        [DataType(DataType.Date)]
        public DateTime upload_date { get; set; } = DateTime.UtcNow;

        [StringLength(250)] [Display(Name = "Image1")]
        public string? imagePath1 { get; set; }

        [StringLength(250)] [Display(Name = "Image2")]
        public string? imagePath2 { get; set; }

        [StringLength(250)] [Display(Name = "Image3")]
        public string? imagePath3 { get; set; }
        public bool approbation { get; set; } = false;
    }
}
