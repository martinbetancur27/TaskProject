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
        public Task<int> AddAsync(ImportantTask importantTask);
        public Task<bool> DeleteAsync(int idImportantTask);
        public Task<List<ImportantTask?>> GetOfUserAsync(string idUser);
    }
}