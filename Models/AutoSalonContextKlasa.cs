using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class AutoSalonContextKlasa: DbContext
    {
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<MotoPartner> MotoPartneri { get; set; }
        public DbSet<AutoPartner> AutoPartneri { get; set; }
        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<Motor> Motori { get; set; }

        public AutoSalonContextKlasa(DbContextOptions options): base(options)
        {}
    }
}