using DOMAIN.Models;

namespace DOMAIN.IRepository
{
    public interface IBookRepo : IGenericRepo<Book>
    {
        Task<IEnumerable<Book>> FindByTitle(string title);

        Task<IEnumerable<Book>> FindByCategory(string title);
    }
}
