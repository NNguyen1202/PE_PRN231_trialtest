using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObjects.Entities
{
    public partial class WatercolorsPainting
    {
        [Key]
        [Required]
        public string PaintingId { get; set; } = null!;
        [Required]
        [BeginWithCapitalLetterAttribute]
        public string PaintingName { get; set; } = null!;
        [Required]
        public string? PaintingDescription { get; set; }
        [Required]
        public string? PaintingAuthor { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? PublishYear { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public string? StyleId { get; set; }
        [JsonIgnore]
        public virtual Style? Style { get; set; }
    }
}
