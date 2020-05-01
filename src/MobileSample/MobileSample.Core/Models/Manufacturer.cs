namespace MobileSample.Core.Models
{
    public class Manufacturer : BaseEntities
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public override bool ValidateRequired()
        {
            return !string.IsNullOrWhiteSpace(Id) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(CompanyId) &&
                   !string.IsNullOrWhiteSpace(Country);
        }
    }
}