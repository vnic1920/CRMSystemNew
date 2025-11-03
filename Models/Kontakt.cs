using System.ComponentModel.DataAnnotations;

namespace CRMSystemNew.Models
{
    public class Kontakt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vorname ist erforderlich")]
        public string Vorname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nachname ist erforderlich")]
        public string Nachname { get; set; } = string.Empty;

        public string? Position { get; set; }

        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse")]
        public string? Email { get; set; }

        public string? Telefon { get; set; }
        public bool IstHauptansprechpartner { get; set; }

        // Foreign Key
        public int KundeId { get; set; }

        // Navigation Property
        public virtual Kunde? Kunde { get; set; }

        public DateTime Erstellungsdatum { get; set; } = DateTime.Now;
    }
}