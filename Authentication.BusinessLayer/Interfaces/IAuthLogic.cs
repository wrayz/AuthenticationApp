using System.Threading.Tasks;
using Authentication.Models;

namespace Authentication.BusinessLayer.Interfaces
{
    public interface IAuthLogic
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> IsUserExists(string username);
    }
}
