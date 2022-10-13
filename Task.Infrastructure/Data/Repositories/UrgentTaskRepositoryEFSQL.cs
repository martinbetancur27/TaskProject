using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;
using Task.Core.Interfaces.Repositories;

namespace Task.Infrastructure.Data.Repositories
{
    public class UrgentTaskRepositoryEFSQL : IUrgentTaskRepository
    {
        private readonly ApplicationDbContext _databaseContext;


        public UrgentTaskRepositoryEFSQL(ApplicationDbContext db)
        {
            _databaseContext = db;
        }


        public async Task<bool> AddUrgentTaskAsync(UrgentTask urgentTask)
        {
            try
            {
                await _databaseContext.UrgentTasks.AddAsync(urgentTask);
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public async Task<bool> DeleteUrgentTaskAsync(int idUrgentTask)
        {
            try
            {
                var urgentTaskDb = await FindUrgentTaskAsync(idUrgentTask);

                if (urgentTaskDb == null)
                {
                    return false;
                }

                _databaseContext.UrgentTasks.Remove(urgentTaskDb);
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public async Task<IEnumerable<UrgentTask?>> GetUrgentTasksOfUser(string idUser)
        {
            try
            {
                return _databaseContext.UrgentTasks.Where(x => x.IdUser == idUser).OrderByDescending(d => d.EndDate);
            }
            catch (System.Exception)
            {
                return null;
            }
        }


        public async Task<UrgentTask?> FindUrgentTaskAsync(int idUrgentTask)
        {
            try
            {
                return await _databaseContext.UrgentTasks.FindAsync(idUrgentTask);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
