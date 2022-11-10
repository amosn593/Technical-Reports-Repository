

using DOMAIN.IRepository;

namespace DOMAIN.IConfiguration
{
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRepo Category { get; }

        IBookRepo Book { get; }

        IReportRepo Report { get; }

        IDirectorateRepo Directorate { get; }

        IDepartmentRepo Department { get; }

        Task Save();
    } 
}
