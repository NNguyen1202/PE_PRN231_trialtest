using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public string? StyleId { get; set; }

        [Required]
        public virtual Style? Style { get; set; }
    }
}
