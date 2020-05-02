using MobileSample.Core.Enums;

namespace MobileSample.Core.Models
{
    public class Vehicle : BaseEntities
    {
        public string Name { get; set; }
        public string ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public EVehicleClass VehicleClass { get; set; }

        public override bool ValidatePropertiesRequired()
        {
            return !string.IsNullOrWhiteSpace(Id) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(CompanyId) &&
                   !string.IsNullOrWhiteSpace(ManufacturerId);
        }
    }
}