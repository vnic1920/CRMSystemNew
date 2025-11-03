using Microsoft.EntityFrameworkCore;
using CRMSystemNew.Models;
using CRMSystemNew.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMSystemNew.Services
{
    public class KundeService
    {
        private readonly ApplicationDbContext _context;

        public KundeService(ApplicationDbContext context)
        {
            _context = context;
            EnsureTestData();
        }

        // === KUNDEN-METHODEN ===

        // Alle Kunden laden
        public async Task<List<Kunde>> GetKundenAsync()
        {
            return await _context.Kunden.ToListAsync();
        }

        // Einzelnen Kunden laden
        public async Task<Kunde?> GetKundeAsync(int id)
        {
            return await _context.Kunden.FindAsync(id);
        }

        // Neuen Kunden erstellen
        public async Task<Kunde> AddKundeAsync(Kunde kunde)
        {
            _context.Kunden.Add(kunde);
            await _context.SaveChangesAsync();
            return kunde;
        }

        // Kunde aktualisieren
        public async Task<Kunde> UpdateKundeAsync(Kunde kunde)
        {
            var existingKunde = await _context.Kunden.FindAsync(kunde.Id);
            if (existingKunde != null)
            {
                existingKunde.Name = kunde.Name;
                existingKunde.Email = kunde.Email;
                existingKunde.Telefon = kunde.Telefon;
                existingKunde.Stadt = kunde.Stadt;
                existingKunde.Adresse = kunde.Adresse;
                existingKunde.Postleitzahl = kunde.Postleitzahl;

                await _context.SaveChangesAsync();
            }
            return kunde;
        }

        // Kunden löschen
        public async Task DeleteKundeAsync(int id)
        {
            var kunde = await _context.Kunden.FindAsync(id);
            if (kunde != null)
            {
                _context.Kunden.Remove(kunde);
                await _context.SaveChangesAsync();
            }
        }

        // === KONTAKT-METHODEN ===

        // Kontakte für einen Kunden laden
        public async Task<List<Kontakt>> GetKontakteFürKundeAsync(int kundeId)
        {
            return await _context.Kontakte
                .Where(k => k.KundeId == kundeId)
                .ToListAsync();
        }

        // Neuen Kontakt erstellen
        public async Task<Kontakt> AddKontaktAsync(Kontakt kontakt)
        {
            _context.Kontakte.Add(kontakt);
            await _context.SaveChangesAsync();
            return kontakt;
        }

        // Kontakt löschen
        public async Task DeleteKontaktAsync(int id)
        {
            var kontakt = await _context.Kontakte.FindAsync(id);
            if (kontakt != null)
            {
                _context.Kontakte.Remove(kontakt);
                await _context.SaveChangesAsync();
            }
        }

        // === TESTDATEN ===

        // Test-Daten erstellen
        private void EnsureTestData()
        {
            if (!_context.Kunden.Any())
            {
                // Test-Kunden erstellen
                var kunde1 = new Kunde { Name = "Beispiel GmbH", Email = "info@beispiel.de", Telefon = "0123456789", Stadt = "Berlin" };
                var kunde2 = new Kunde { Name = "Test AG", Email = "contact@test.de", Telefon = "0987654321", Stadt = "München" };
                var kunde3 = new Kunde { Name = "Musterfirma", Email = "service@muster.de", Telefon = "012398765", Stadt = "Hamburg" };

                _context.Kunden.AddRange(kunde1, kunde2, kunde3);
                _context.SaveChanges();

                // Test-Kontakte erstellen
                _context.Kontakte.AddRange(
                    new Kontakt { Vorname = "Max", Nachname = "Mustermann", Position = "Geschäftsführer", Email = "max@beispiel.de", Telefon = "0123456789", KundeId = kunde1.Id, IstHauptansprechpartner = true },
                    new Kontakt { Vorname = "Anna", Nachname = "Musterfrau", Position = "Vertrieb", Email = "anna@beispiel.de", Telefon = "0123456790", KundeId = kunde1.Id },
                    new Kontakt { Vorname = "Thomas", Nachname = "Schmidt", Position = "CEO", Email = "thomas@test.de", Telefon = "0987654321", KundeId = kunde2.Id, IstHauptansprechpartner = true }
                );
                _context.SaveChanges();
            }
        }
    }
}