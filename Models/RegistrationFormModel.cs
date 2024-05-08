using Microsoft.AspNetCore.Mvc;

namespace HWASP.Models
{
    public class RegistrationFormModel
    {
        [FromForm(Name = "user-name-signup")]
        public String UserName { get; set; } = null!;

        [FromForm (Name = "user-email-signup")]
        public String UserEmail {  get; set; }=null!;

        [FromForm(Name = "user-password-signup")]
        public String Password { get; set; }=null!;

        [FromForm(Name = "user-password-signup-repeat")]
        public String PasswordRepeat { get; set; }=null!;

        [FromForm(Name = "signup-avatar")]
        public IFormFile AvatarFile { get; set; } = null!;

        [FromForm(Name = "user-birthday")]
        public DateTime? Birthdate { get; set; } = null!;

        [FromForm(Name = "signup-confirm")]
        public bool Confirm { get; set; }

        //дополнительное поле (не из формы) для имени сохраненного  файла
        public String? SavedFileName { get; set; }
    }
}
