﻿using TP.Core.DTO.UrgentTask;
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
            var newUrgentTask = new UrgentTask
			{
				Description = createUrgentTask.Description,
				EndDate = createUrgentTask.EndDate
			};

            string idUser = await _userService.GetIdAsync();

            if (idUser != null)
            {
                newUrgentTask.IdUser = idUser;
                newUrgentTask.Id = await _urgentTaskRepository.AddAsync(newUrgentTask);
                
                return newUrgentTask;
            }

            return null;
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
