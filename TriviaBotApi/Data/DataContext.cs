using Microsoft.EntityFrameworkCore;
using TriviaBotApi.Models;

namespace TriviaBotApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
    }
}
