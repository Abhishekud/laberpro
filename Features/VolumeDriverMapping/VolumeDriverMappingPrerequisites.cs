using System.ComponentModel.DataAnnotations;

namespace LaborPro.Automation.Features.VolumeDriverMapping
{
    public class VolumeDriverMappingPrerequisites
    {
        [Required]
        public string VolumeDriverMappingSet { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string VolumeDriver { get; set; }
        [Required]
        public string UnitsOfMeasure { get; set; }

    }
}
