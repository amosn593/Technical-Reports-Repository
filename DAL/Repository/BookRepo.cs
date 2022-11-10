using DAL.Data;
using DOMAIN.IRepository;
using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class BookRepo : GenericRepo<Book>, IBookRepo
    {
        public BookRepo(ReportsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> FindByTitle(string title)
        {
            try
            {
                var books = await _context.Books
                    .Where(c => c.Title.Contains(title))
                    .ToListAsync();


                return books;

            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
