using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Entities;
using TP.Core.Interfaces.Repositories;
using TP.Core.Interfaces.Services;

namespace TP.Core.Services
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


		public async Task<int> AddAsync(ImportantTask importantTask)
		{
            string idUser = await _userService.GetIdAsync();
			Console.WriteLine("ID " + idUser);
            if (idUser != null)
			{
				importantTask.IdUser = idUser;
				
				return await _importantTaskRepository.AddAsync(importantTask);
            }

			return 0;
        }


		public async Task<bool> DeleteAsync(int idImportantTask)
		{
			return await _importantTaskRepository.DeleteAsync(idImportantTask);
        }

		public async Task<List<ImportantTask?>> GetOfUserAsync()
		{
			string idUser = await _userService.GetIdAsync();

			if(idUser == null)
			{
				return null;
			}

			return await _importantTaskRepository.GetOfUserAsync(idUser);
        }
	}
}
