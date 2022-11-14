using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TP.Core.Interfaces.Services;

namespace TP.Core.Services
{
    public class UserManagerService : IUserService
    {
        private readonly IHttpContextAccessor _userManager;

        public UserManagerService(IHttpContextAccessor userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> GetIdAsync()
        {
            return _userManager.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
