namespace HWASP.Models
{
    public class RandomServiceTestPageModel
    {
        public String PageTitle { get; set; } = null!;
        public string code { get; set; } = null!;
        public string salt {  get; set; } = null!;
        public string fileName { get; set; } = null!;

    }
}
