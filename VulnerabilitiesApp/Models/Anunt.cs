using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VulnerabilitiesApp.Models
{
    public class Anunt : BaseModel
    {
        public long Id { get; set; }

        public string Titlu { get; set; }

        public DateTime Data { get; set; }

        public string Descriere { get; set; }

        public long IdCategorie { get; set; }

        public long IdSubCategorie { get; set; }

        public long Pret { get; set; }

        public long IdValuta { get; set; }

        public bool Activ { get; set; }
    }
}
