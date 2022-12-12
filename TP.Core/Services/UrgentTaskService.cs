using TP.Core.DTO.UrgentTask;
using TP.Core.Entities;
using TP.Core.Interfaces.Repositories;
using TP.Core.Interfaces.Services;

namespace TP.Core.Services
{
    public class UrgentTaskService : IUrgentTaskService
    {
        private readonly IUrgentTaskRepository _urgentTaskRepository;
        private readonly IUserService _userService;

        public UrgentTaskService(IUrgentTaskRepository urgentTaskRepository, IUserService userService)
        {
            _urgentTaskRepository = urgentTaskRepository;
            _userService = userService;
        }

        public async Task<UrgentTask?> AddAsync(CreateUrgentTaskDTO createUrgentTask)
        {
            string idUser = await _userService.GetIdAsync();

            if (idUser == null)
            {
                return null;
            }

            var newUrgentTask = new UrgentTask
			{
				Description = createUrgentTask.Description,
				EndDate = createUrgentTask.EndDate,
                IdUser = idUser
			};

            newUrgentTask.Id = await _urgentTaskRepository.AddAsync(newUrgentTask);
            
            return newUrgentTask;
        }

        public async Task<bool> DeleteAsync(int idUrgentTask)
        {
            return await _urgentTaskRepository.DeleteAsync(idUrgentTask);
        }

        public async Task<List<UrgentTask>?> GetOfUserAsync()
        {
            string idUser = await _userService.GetIdAsync();

            return idUser == null ? null : _urgentTaskRepository.GetOfUser(idUser);
        }
    }
}
