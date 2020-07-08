using System.Threading.Tasks;
using Authentication.DataAccessLayer;
using Authentication.Domain.Interfaces;
using Authentication.Domain.Models;

namespace Authentication.BusinessLayer
{
    public class AuthBusinessLogic : IAuthLogic
    {
        IRepository<User> _repository;

        public AuthBusinessLogic()
        {
            _repository = new AuthRepository();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _repository.CreateAsync(user);
            await _repository.SaveAsync();

            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _repository.GetAsync(x => x.UserName == username);

            if (user == null) return null;

            if (!VerifyPasswordHash(user, password)) return null;

            return user;
        }

        public async Task<bool> IsUserExists(string username)
        {
            return await _repository.AnyAsync(x => x.UserName == username);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hamc = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hamc.Key;
                passwordHash = hamc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(User user, string password)
        {
            using(var hamc = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hamc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i]) return false;
                }
            }

            return true;
        }
    }
}
