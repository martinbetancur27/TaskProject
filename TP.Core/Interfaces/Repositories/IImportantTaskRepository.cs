using TP.Core.Entities;

namespace TP.Core.Interfaces.Repositories
{
    public interface IImportantTaskRepository
    {
        public Task<int> AddAsync(ImportantTask importantTask);
        public Task<bool> DeleteAsync(int idImportantTask);
        public List<ImportantTask>? GetOfUser(string idUser);
    }
}