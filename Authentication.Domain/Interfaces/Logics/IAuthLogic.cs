using System.Threading.Tasks;
using Authentication.Domain.Models;

namespace Authentication.Domain.Interfaces
{
    public interface IAuthLogic
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> IsUserExists(string username);
    }
}
