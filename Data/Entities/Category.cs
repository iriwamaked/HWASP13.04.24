namespace HWASP.Data.Entities
{
    public class Category
    {
        public   Guid     Id           { get; set; }
        public   String   Slug         { get; set; } = null!;
        public   String   Name         { get; set; } = null!;
        public   String   Description  { get; set; } = null!;
        public   String   ImageUrl     { get; set; } = null!;
        public   Boolean  IsActive     { get; set; } = true;
    }
}
