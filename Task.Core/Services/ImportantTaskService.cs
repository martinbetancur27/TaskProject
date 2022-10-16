using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;
using Task.Core.Interfaces.Repositories;
using Task.Core.Interfaces.Services;

namespace Task.Core.Services
{
	public class ImportantTaskService : IImportantTaskService
	{
        private readonly IImportantTaskRepository _importantTaskRepository;
        private readonly IUserService _userService;


        public ImportantTaskService(IImportantTaskRepository importantTaskRepository, IUserService userService)
		{
			_importantTaskRepository = importantTaskRepository;
            _userService = userService;
        }


		public async Task<int> AddImportantTaskAsync(ImportantTask importantTask)
		{
            string idUser = await _userService.GetUserIdAsync();
			Console.WriteLine("ID " + idUser);
            if (idUser != null)
			{
				importantTask.IdUser = idUser;
				
				return await _importantTaskRepository.AddImportantTaskAsync(importantTask);
            }

			return 0;
        }


		public async Task<bool> DeleteImportantTaskAsync(int idImportantTask)
		{
			return await _importantTaskRepository.DeleteImportantTaskAsync(idImportantTask);
        }

		public async Task<List<ImportantTask?>> GetImportantTasksOfUserAsync()
		{
			string idUser = await _userService.GetUserIdAsync();

			if(idUser == null)
			{
				return null;
			}

			return await _importantTaskRepository.GetImportantTasksOfUserAsync(idUser);
        }
	}
}
