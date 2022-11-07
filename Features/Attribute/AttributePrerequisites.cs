using System.ComponentModel.DataAnnotations;

namespace LaborPro.Automation.Features.Attribute
{
    public class AttributePrerequisites
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Attribute { get; set; }

    }
}
