using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<string> GetUserIdAsync();
    }
}
