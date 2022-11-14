using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Entities;

namespace TP.Core.Interfaces.Services
{
    public interface IUrgentTaskService
	{
        public Task<int> AddAsync(UrgentTask urgentTask);
        public Task<bool> DeleteAsync(int idUrgentTask);
        public Task<List<UrgentTask?>> GetOfUserAsync();
    }
}
