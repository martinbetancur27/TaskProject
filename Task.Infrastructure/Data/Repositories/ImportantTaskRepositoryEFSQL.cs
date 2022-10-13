﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;
using Task.Core.Interfaces.Repositories;

namespace Task.Infrastructure.Data.Repositories
{
    public class ImportantTaskRepositoryEFSQL : IImportantTaskRepository
    {
        private readonly ApplicationDbContext _databaseContext;


        public ImportantTaskRepositoryEFSQL(ApplicationDbContext db)
        {
            _databaseContext = db;
        }


        public async Task<bool> AddImportantTaskAsync(ImportantTask importantTask)
        {
            try
            {
                await _databaseContext.ImportantTasks.AddAsync(importantTask);
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public async Task<bool> DeleteImportantTaskAsync(int idImportantTask)
        {
            try
            {
                var importantTaskDb = await FindImportantTaskAsync(idImportantTask);
                
                if (importantTaskDb == null)
                {
                    return false;
                }

                _databaseContext.ImportantTasks.Remove(importantTaskDb);
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public async Task<IEnumerable<ImportantTask?>> GetImportantTasksOfUser(string idUser)
        {
            try
            {
                return _databaseContext.ImportantTasks.Where(x => x.IdUser == idUser).OrderByDescending(d => d.EndDate);
            }
            catch (System.Exception)
            {
                return null;
            }
        }


        public async Task<ImportantTask?> FindImportantTaskAsync(int idImportantTask)
        {
            try
            {
                return await _databaseContext.ImportantTasks.FindAsync(idImportantTask);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
