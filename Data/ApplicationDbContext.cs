using Microsoft.EntityFrameworkCore;
using CRMSystemNew.Models;

namespace CRMSystemNew.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Kontakt> Kontakte { get; set; }
        public DbSet<Aufgabe> Aufgaben { get; set; }
    }
}