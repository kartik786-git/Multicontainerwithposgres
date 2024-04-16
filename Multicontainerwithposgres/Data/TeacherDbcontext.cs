using Microsoft.EntityFrameworkCore;
using Multicontainerwithposgres.Entity;

namespace Multicontainerwithposgres.Data
{
    public class TeacherDbcontext : DbContext
    {
        public TeacherDbcontext(DbContextOptions<TeacherDbcontext> dbContextOptions):
            base(dbContextOptions) { }


        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
