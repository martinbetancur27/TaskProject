using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Core.Entities
{
    public class ImportantTask
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public string IdUser { get; set; }

    }
}
