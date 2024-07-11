using System.ComponentModel.DataAnnotations;

namespace PEPRN231_SU24TrialTest_SE150329_FE.Model
{
    public class Style
    {
        [Key]
        public string? StyleId { get; set; }
        public string? StyleName { get; set; }
        public string? StyleDescription { get; set; }
        public string? OriginalCountry { get; set; }
    }
}
