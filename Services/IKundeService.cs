using CRMSystemNew.Models;
using System.Threading.Tasks;

namespace CRMSystemNew.Services
{
    public interface IKundeService
    {
        Task<List<Kunde>> GetAllKundenAsync();
        Task<Kunde?> GetKundeByIdAsync(int id);
        Task AddKundeAsync(Kunde kunde);
        Task UpdateKundeAsync(Kunde kunde);
        Task DeleteKundeAsync(int id);
        Task<(List<Kunde> Kunden, int TotalCount)> GetKundenPagedAsync(int page, int pageSize, string searchString);
    }
}