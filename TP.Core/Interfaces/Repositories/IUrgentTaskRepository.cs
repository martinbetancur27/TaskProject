using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Entities;

namespace TP.Core.Interfaces.Repositories
{
    public interface IUrgentTaskRepository
    {
        public Task<int> AddUrgentTaskAsync(UrgentTask urgentTask);
        public Task<bool> DeleteUrgentTaskAsync(int idUrgentTaskImportantTask);
        public Task<List<UrgentTask?>> GetUrgentTasksOfUserAsync(string idUser);
    }
}
