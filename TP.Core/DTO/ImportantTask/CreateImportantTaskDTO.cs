using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Core.DTO.ImportantTask
{
	public class CreateImportantTaskDTO
	{
        public string Description { get; set; }

        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
