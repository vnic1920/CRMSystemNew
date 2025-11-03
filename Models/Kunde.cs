using System.ComponentModel.DataAnnotations;

namespace CRMSystemNew.Models
{
    public class Kunde
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kundenname ist erforderlich")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Adresse { get; set; }

        [Phone(ErrorMessage = "Ungültige Telefonnummer")]
        public string? Telefon { get; set; }

        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse")]
        public string? Email { get; set; }

        public DateTime ErstelltAm { get; set; } = DateTime.Now;
        public DateTime? GeändertAm { get; set; }

        // Navigation Properties
        public virtual ICollection<Kontakt> Kontakte { get; set; } = new List<Kontakt>();
        public virtual ICollection<Aufgabe> Aufgaben { get; set; } = new List<Aufgabe>();
    }
}