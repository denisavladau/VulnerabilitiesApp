using VulnerabilitiesApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VulnerabilitiesApp.Models
{
    public class VulnerabilitiesContext : DbContext
    {
        public VulnerabilitiesContext() : base("VulnerabilitiesContext")
        {

        }

        public DbSet<Utilizator> Utilizatori { get; set; }

        public DbSet<Valuta> Valute { get; set; }

        public DbSet<Categorie> Categorii { get; set; }

        public DbSet<Anunt> Anunturi { get; set; }

        public DbSet<AnuntUtilizator> AnunturiUtilizatori { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
