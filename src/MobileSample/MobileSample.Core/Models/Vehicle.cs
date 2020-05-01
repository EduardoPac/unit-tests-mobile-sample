using MobileSample.Core.Enums;

namespace MobileSample.Core.Models
{
    public class Vehicle : BaseEntities
    {
        public string Name { get; set; }
        public string ConstructorId { get; set; }
        public Constructor Constructor { get; set; }
        public EVehicleClass VehicleClass { get; set; }

        public override bool ValidateRequired()
        {
            return !string.IsNullOrWhiteSpace(Id) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(ConstructorId);
        }
    }
}