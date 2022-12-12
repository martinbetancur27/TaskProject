using TP.Core.DTO.ImportantTask;
using TP.Core.Entities;

namespace TP.Core.Interfaces.Services
{
    public interface IImportantTaskService
    {
        public Task<ImportantTask?> AddAsync(CreateImportantTaskDTO createImportantTask);
        public Task<bool> DeleteAsync(int idImportantTask);
        public Task<List<ImportantTask>?> GetOfUserAsync();
    }
}
