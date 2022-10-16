using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.DTO.UrgentTask
{
	public class CreateUrgentTaskDTO
	{
        public string Description { get; set; }

        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
