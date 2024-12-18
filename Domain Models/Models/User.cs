using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Ugyldig e-mailadresse")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adgangskode er påkrævet")]
        [MinLength(6, ErrorMessage = "Adgangskoden skal være på mindst 6 tegn")]
        public string Password { get; set; }

        public string Phone { get; set; } = string.Empty;
    }
}
