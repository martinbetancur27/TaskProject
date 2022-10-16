using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Interfaces.Services;

namespace Task.Core.Services
{
    public class UserManagerService : IUserService
    {
        private readonly IHttpContextAccessor _userManager;

        public UserManagerService(IHttpContextAccessor userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> GetUserIdAsync()
        {
            return _userManager.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
