using System.ComponentModel.DataAnnotations;
namespace LaborPro.Automation.Features.VolumeDriverValueSet
{
    public class VolumeDriverValueSetPrerequisites
    {
        [Required]
        public string Department { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string UnitsOfMeasure { get; set; }
        [Required]
        public string VolumeDriver { get; set; }
    }
}
