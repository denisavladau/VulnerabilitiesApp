using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VulnerabilitiesApp.Models;

namespace VulnerabilitiesApp.Models
{
    public class VulnerabilitiesAppContext : DbContext
    {
        public VulnerabilitiesAppContext (DbContextOptions<VulnerabilitiesAppContext> options)
            : base(options)
        {
        }

        public DbSet<VulnerabilitiesApp.Models.Utilizator> Utilizator { get; set; }

        public DbSet<VulnerabilitiesApp.Models.Anunt> Anunt { get; set; }

        public DbSet<VulnerabilitiesApp.Models.Categorie> Categorie { get; set; }

        public DbSet<VulnerabilitiesApp.Models.Valuta> Valuta { get; set; }

        public DbSet<VulnerabilitiesApp.Models.AnuntUtilizator> AnuntUtilizator { get; set; }
    }
}
