using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission08_Team0215.Models
{
    public class UserTaskQuadrantContext : DbContext
    {
        public UserTaskQuadrantContext(DbContextOptions<UserTaskQuadrantContext> options) : base(options) //contructor
        {
        }
        public DbSet<UserTask> UserTask { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
