

using DOMAIN.Models;

namespace DOMAIN.IRepository
{
    public interface IDirectorateRepo : IGenericRepo<Directorate>
    {
        Task<Directorate> FindByName(string name);
    }
}
