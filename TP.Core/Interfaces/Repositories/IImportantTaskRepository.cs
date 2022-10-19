﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Entities;

namespace TP.Core.Interfaces.Repositories
{
    public interface IImportantTaskRepository
    {
        public Task<int> AddImportantTaskAsync(ImportantTask importantTask);
        public Task<bool> DeleteImportantTaskAsync(int idImportantTask);
        public Task<List<ImportantTask?>> GetImportantTasksOfUserAsync(string idUser);
    }
}