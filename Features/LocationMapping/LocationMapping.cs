using System.ComponentModel.DataAnnotations;

namespace LaborPro.Automation.Features.LocationMapping
{
    public class LocationMapping
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string VolumeDriverMappingSet { get; set; }
        [Required]
        public string CharacteristicSet { get; set; }
    }
}
