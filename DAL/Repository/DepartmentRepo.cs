

using DAL.Data;
using DOMAIN.IRepository;
using DOMAIN.Models;

namespace DAL.Repository
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(ReportsDbContext context) : base(context)
        {

        }
    }
}
