

using DAL.Data;
using DAL.Repository;
using DOMAIN.IConfiguration;
using DOMAIN.IRepository;

namespace DAL.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportsDbContext _context;

        public UnitOfWork(ReportsDbContext context)
        {
            _context = context;
        }

     

        public IReportRepo Report => new ReportRepo(_context);

        public IDirectorateRepo Directorate => new DirectorateRepo(_context);

        public IDepartmentRepo Department => new DepartmentRepo(_context);

        public ICategoryRepo Category => new CategoryRepo(_context);

        public IBookRepo Book => new BookRepo(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
