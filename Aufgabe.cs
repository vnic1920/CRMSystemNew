using System.ComponentModel.DataAnnotations;

namespace CRMSystemNew.Data.Models
{
    public class Aufgabe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titel { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Beschreibung { get; set; }

        public DateTime Fälligkeitsdatum { get; set; }
        public DateTime ErstelltAm { get; set; } = DateTime.Now;
        public bool IstErledigt { get; set; } = false;

        // Fremdschlüssel
        public int KundeId { get; set; }

        // Navigation Property
        public virtual Kunde Kunde { get; set; } = null!;
    }
}