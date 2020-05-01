using System.Collections.Generic;
using System.Linq;
using MobileSample.Core.Enums;

namespace MobileSample.Core.Models
{
    public class User : BaseEntities
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public EConductorClass ConductorClass { get; set; }
        public string[] VehicleIds { get; set; }
        public List<Vehicle> Vehicles { get; set; }


        public override bool ValidateRequired()
        {
            return !string.IsNullOrWhiteSpace(Id) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Age) &&
                   VehicleIds.Any();
        }
        
    }
}