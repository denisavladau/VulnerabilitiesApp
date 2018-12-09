using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VulnerabilitiesApp.Models
{
    public class Utilizator : BaseModel
    {
        public long Id { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }
    }
}
