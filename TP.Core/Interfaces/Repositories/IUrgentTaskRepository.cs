﻿using TP.Core.Entities;

namespace TP.Core.Interfaces.Repositories
{
    public interface IUrgentTaskRepository
    {
        public Task<int> AddAsync(UrgentTask urgentTask);
        public Task<bool> DeleteAsync(int idUrgentTaskImportantTask);
        public Task<List<UrgentTask>?> GetOfUserAsync(string idUser);
    }
}
