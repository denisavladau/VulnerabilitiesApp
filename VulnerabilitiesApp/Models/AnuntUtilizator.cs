using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VulnerabilitiesApp.Models
{
    public class AnuntUtilizator : BaseModel
    {
        public long Id { get; set; }

        public long IdUtilizator { get; set; }

        public long IdAnunt { get; set; }
    }
}
