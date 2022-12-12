using TP.Core.Entities;

namespace TP.Core.Interfaces.Repositories
{
    public interface IUrgentTaskRepository
    {
        public Task<int> AddAsync(UrgentTask urgentTask);
        public Task<bool> DeleteAsync(int idUrgentTaskImportantTask);
        public List<UrgentTask>? GetOfUser(string idUser);
    }
}
