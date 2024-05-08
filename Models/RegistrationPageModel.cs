namespace HWASP.Models
{
    public class RegistrationPageModel
    {
        public String PageTitle { get; set; } = null!;
        public String? Message {  get; set; } = null!;
        public bool? IsSuccess { get; set; }
        public RegistrationFormModel? FormModel { get; set; }

        public Dictionary<String, String> ValidationErrors { get; set; } = null!;
        public bool IsInitialLoad { get; set; } // Поле для отслеживания первой загрузки страницы
    }
}
