using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Authentication.DataAccessLayer.Data;
using Authentication.Domain.Interfaces;
using Authentication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccessLayer
{
    public class AuthRepository : IRepository<User>
    {
        private readonly DataContext _context;

        public AuthRepository()
        {
            _context = new DataContext();
        }
        public Task<int> CreateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AnyAsync(predicate);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.FirstOrDefaultAsync(predicate);
        }

        public Task<System.Linq.IQueryable<User>> ReadsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
