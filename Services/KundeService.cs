using Microsoft.EntityFrameworkCore;
using CRMSystemNew.Data;
using CRMSystemNew.Models;

namespace CRMSystemNew.Services
{
    public class KundeService : IKundeService
    {
        private readonly ApplicationDbContext _context;

        public KundeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kunde>> GetAllKundenAsync()
        {
            return await _context.Kunden
                .OrderBy(k => k.Name)
                .ToListAsync();
        }

        public async Task<Kunde?> GetKundeByIdAsync(int id)
        {
            return await _context.Kunden
                .FirstOrDefaultAsync(k => k.Id == id);
        }

        public async Task<Kunde> CreateKundeAsync(Kunde kunde)
        {
            kunde.ErstelltAm = DateTime.Now;
            _context.Kunden.Add(kunde);
            await _context.SaveChangesAsync();
            return kunde;
        }

        public async Task<Kunde> UpdateKundeAsync(Kunde kunde)
        {
            kunde.GeändertAm = DateTime.Now;
            _context.Kunden.Update(kunde);
            await _context.SaveChangesAsync();
            return kunde;
        }

        public async Task<bool> DeleteKundeAsync(int id)
        {
            var kunde = await _context.Kunden.FindAsync(id);
            if (kunde == null) return false;

            _context.Kunden.Remove(kunde);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}