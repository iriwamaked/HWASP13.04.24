using HWASP.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HWASP.Data.Context
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; set; }
       
        public DataContext(DbContextOptions options) : base(options) { }

        //указываем связи между данными и ограничения в специальном методе
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                 .HasIndex(u => u.Email) 
                 .IsUnique();              

        }
    }
}
