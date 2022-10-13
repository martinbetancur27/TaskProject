﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Core.Interfaces.Repositories
{
    public interface IUrgentTaskRepository
    {
        public Task<bool> AddUrgentTaskAsync(UrgentTask urgentTask);
        public Task<bool> DeleteUrgentTaskAsync(int idUrgentTaskImportantTask);
        public Task<IEnumerable<UrgentTask?>> GetUrgentTasksOfUser(string idUser);
    }
}
