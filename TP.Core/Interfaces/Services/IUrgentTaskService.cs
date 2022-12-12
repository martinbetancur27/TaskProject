using TP.Core.DTO.UrgentTask;
using TP.Core.Entities;

namespace TP.Core.Interfaces.Services
{
    public interface IUrgentTaskService
    {
        public Task<UrgentTask?> AddAsync(CreateUrgentTaskDTO createUrgentTask);
        public Task<bool> DeleteAsync(int idUrgentTask);
        public Task<List<UrgentTask>?> GetOfUserAsync();
    }
}
