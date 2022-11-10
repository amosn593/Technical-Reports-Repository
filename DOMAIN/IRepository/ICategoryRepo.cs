using DOMAIN.Models;

namespace DOMAIN.IRepository
{
    public interface  ICategoryRepo : IGenericRepo<Category>
    {
        Task<Category> FindByName(string name);
    }
}
