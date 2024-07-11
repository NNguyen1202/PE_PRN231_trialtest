using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PEPRN231_SU24TrialTest_SE150329_FE.Model
{
    public class WatercolorsPainting
    {
        [Key]
        [Required]
        public string? PaintingId { get; set; }
        [Required]
        [BeginWithCapitalLetter]
        public string? PaintingName { get; set; }
        [Required]
        public string? PaintingDescription { get; set; }
        [Required]
        public string? PaintingAuthor { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(1000, int.MaxValue)]
        public int PublishYear { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public string? StyleId { get; set; }
        public virtual Style? Style { get; set; }
    }
}
