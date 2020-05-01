namespace MobileSample.Core.Models
{
    public abstract class BaseEntities
    {
        public string Id { get; set; }
        public bool Removed { get; set; }
        public abstract bool ValidateRequired();
    }
}