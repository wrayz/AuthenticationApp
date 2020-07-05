using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccessLayer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
