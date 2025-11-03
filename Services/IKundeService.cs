using CRMSystemNew.Models;

namespace CRMSystemNew.Services
{
    public interface IKundeService
    {
        Task<List<Kunde>> GetAllKundenAsync();
        Task<Kunde?> GetKundeByIdAsync(int id);
        Task<Kunde> CreateKundeAsync(Kunde kunde);
        Task<Kunde> UpdateKundeAsync(Kunde kunde);
        Task<bool> DeleteKundeAsync(int id);
    }
}