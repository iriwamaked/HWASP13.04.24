namespace HWASP.Data.Entities
{
    public class ServiceProvided
    {
        public Guid       Id          { get; set; }
        public Guid       CategoryId  { get; set; }
        public String     Name        { get; set; } = null!;
        public String     Description { get; set; } = null!;
        public Boolean    IsActive    { get; set; } = true;
        public Double      Price      { get; set; } 
    }
}
