using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ReportsDbContext : DbContext
    {
        public ReportsDbContext(DbContextOptions<ReportsDbContext> options)
            : base(options)
        {
        }

        public DbSet<DOMAIN.Models.Category> Categories { get; set; }
        public DbSet<DOMAIN.Models.Book> Books { get; set; }
        public DbSet<DOMAIN.Models.Report> Reports { get; set; }
        public DbSet<DOMAIN.Models.Directorate> Directorates { get; set; }
        public DbSet<DOMAIN.Models.Department> Departments { get; set; }
    }
}
