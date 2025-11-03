using System.ComponentModel.DataAnnotations;

namespace CRMSystemNew.Models
{
    public class Kontakt
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Vorname { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nachname { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Telefon { get; set; }

        public string? Position { get; set; }

        // Foreign Key
        public int KundeId { get; set; }

        // Navigation Property
        public virtual Kunde Kunde { get; set; } = null!;
    }
}