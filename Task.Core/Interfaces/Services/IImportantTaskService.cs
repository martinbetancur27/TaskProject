using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Core.Interfaces.Services
{
	public interface IImportantTaskService
	{
        public Task<int> AddImportantTaskAsync(ImportantTask importantTask);
        public Task<bool> DeleteImportantTaskAsync(int idImportantTask);
        public Task<List<ImportantTask?>> GetImportantTasksOfUserAsync();
    }
}
