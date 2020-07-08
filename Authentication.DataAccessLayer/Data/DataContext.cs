using Authentication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccessLayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            //TODO: 之後要拿掉此建構式
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
