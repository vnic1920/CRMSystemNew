using System.ComponentModel.DataAnnotations;

namespace CRMSystemNew.Models
{
    public class Kunde
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kundenname ist erforderlich")]
        [StringLength(100, ErrorMessage = "Name darf max. 100 Zeichen haben")]
        public string Name { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse")]
        public string? Email { get; set; }

        public string? Telefon { get; set; }
        public string? Adresse { get; set; }
        public string? Stadt { get; set; }
        public string? Postleitzahl { get; set; }
        public DateTime Erstellungsdatum { get; set; } = DateTime.Now;

        // Navigation Property für Kontakte
        public virtual ICollection<Kontakt> Kontakte { get; set; } = new List<Kontakt>();
    }
}