using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Core.Interfaces.Repositories
{
    public interface IImportantTaskRepository
    {
        public Task<bool> AddImportantTaskAsync(ImportantTask importantTask);
        public Task<bool> DeleteImportantTaskAsync(int idImportantTask);
        public Task<IEnumerable<ImportantTask?>> GetImportantTasksOfUser(string idUser);
    }
}