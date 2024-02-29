using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission08_Team0215.Models
{
    public class UserTaskFormContext : DbContext
    {
        public UserTaskFormContext(DbContextOptions<UserTaskFormContext> options) : base(options) //contructor
        {
        }
        public DbSet<UserTask> UserTask { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
