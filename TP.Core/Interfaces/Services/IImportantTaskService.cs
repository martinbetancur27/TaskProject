using TP.Core.Entities;

namespace TP.Core.Interfaces.Services
{
    public interface IImportantTaskService
    {
        public Task<int> AddAsync(ImportantTask importantTask);
        public Task<bool> DeleteAsync(int idImportantTask);
        public Task<List<ImportantTask?>> GetOfUserAsync();
    }
}
