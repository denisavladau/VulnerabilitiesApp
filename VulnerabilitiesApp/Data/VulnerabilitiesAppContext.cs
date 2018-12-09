using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VulnerabilitiesApp.Models
{
    public class VulnerabilitiesAppContext : DbContext
    {
        public VulnerabilitiesAppContext (DbContextOptions<VulnerabilitiesAppContext> options)
            : base(options)
        {
        }

        public DbSet<VulnerabilitiesApp.Models.Utilizator> Utilizator { get; set; }
    }
}
