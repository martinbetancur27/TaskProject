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
	public class UrgentTaskService : IUrgentTaskService
	{
        private readonly IUrgentTaskRepository _urgentTaskRepository;
        private readonly IUserService _userService;


        public UrgentTaskService(IUrgentTaskRepository urgentTaskRepository, IUserService userService)
		{
            _urgentTaskRepository = urgentTaskRepository;
            _userService = userService;
        }

		public async Task<int> AddUrgentTaskAsync(UrgentTask urgentTask)
		{
            string idUser = await _userService.GetUserIdAsync();
            Console.WriteLine("ID " + idUser);
            if (idUser != null)
            {
                urgentTask.IdUser = idUser;

                return await _urgentTaskRepository.AddUrgentTaskAsync(urgentTask);
            }

            return 0;
        }

		public async Task<bool> DeleteUrgentTaskAsync(int idUrgentTask)
		{
            return await _urgentTaskRepository.DeleteUrgentTaskAsync(idUrgentTask);
        }

		public async Task<List<UrgentTask?>> GetUrgentTasksOfUserAsync()
		{
            string idUser = await _userService.GetUserIdAsync();

            if (idUser == null)
            {
                return null;
            }

            return await _urgentTaskRepository.GetUrgentTasksOfUserAsync(idUser);
        }
	}
}
