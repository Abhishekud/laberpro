using System.ComponentModel.DataAnnotations;

namespace LaborPro.Automation.Features.VolumeDriverValueSet
{
    public class VolumeDriverValuesRecord
    {
        [Required]
        public string VolumeDriverValueSet { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string VolumeDriver { get; set; }
        [Required]
        public string LocationDescription { get; set; }
        [Required]
        public string Value { get; set; }

    }
}
