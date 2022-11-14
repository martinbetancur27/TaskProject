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

        public async Task<int> AddAsync(UrgentTask urgentTask)
        {
            string idUser = await _userService.GetIdAsync();

            if (idUser != null)
            {
                urgentTask.IdUser = idUser;

                return await _urgentTaskRepository.AddAsync(urgentTask);
            }

            return 0;
        }

        public async Task<bool> DeleteAsync(int idUrgentTask)
        {
            return await _urgentTaskRepository.DeleteAsync(idUrgentTask);
        }

        public async Task<List<UrgentTask?>> GetOfUserAsync()
        {
            string idUser = await _userService.GetIdAsync();

            if (idUser == null)
            {
                return null;
            }

            return await _urgentTaskRepository.GetOfUserAsync(idUser);
        }
    }
}
