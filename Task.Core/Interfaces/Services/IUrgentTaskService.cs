using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Core.Interfaces.Services
{
    public interface IUrgentTaskService
	{
        public Task<int> AddUrgentTaskAsync(UrgentTask urgentTask);
        public Task<bool> DeleteUrgentTaskAsync(int idUrgentTask);
        public Task<List<UrgentTask?>> GetUrgentTasksOfUserAsync();
    }
}
