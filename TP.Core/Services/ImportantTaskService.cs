using TP.Core.DTO.ImportantTask;
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

		public async Task<ImportantTask?> AddAsync(CreateImportantTaskDTO createImportantTask)
		{
			string idUser = await _userService.GetIdAsync();

			if (idUser == null)
			{
				return null;
			}

			var newImportantTask = new ImportantTask
			{
				Description = createImportantTask.Description,
				EndDate = createImportantTask.EndDate,
				IdUser = idUser
			};

			newImportantTask.Id = await _importantTaskRepository.AddAsync(newImportantTask);

			return newImportantTask;
		}

		public async Task<bool> DeleteAsync(int idImportantTask)
		{
			return await _importantTaskRepository.DeleteAsync(idImportantTask);
		}

		public async Task<List<ImportantTask>?> GetOfUserAsync()
		{
			string idUser = await _userService.GetIdAsync();

			return idUser == null ? null : _importantTaskRepository.GetOfUser(idUser);
		}
	}
}
