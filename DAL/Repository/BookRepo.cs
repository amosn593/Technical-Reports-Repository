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

        public override async Task<IEnumerable<Book>> FindAll()
        {

            try
            {
                var books = await _context.Books
                    .Include(d => d.Category)
                    .ToListAsync();


                return books;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> FindByCategory(string category)
        {
            try
            {
                var books = await _context.Books
                    .Where(c => c.Category.Name.Contains(category))
                    //.Include(d => d.Category)
                    .ToListAsync();


                return books;

            }
            catch (Exception)
            {
                throw;

            }
        }

        public override async Task<Book> FindById(int id)
        {

            try
            {
                var book = await _context.Books
                    .Include(d => d.Category)
                    .FirstOrDefaultAsync(i => i.BookId == id);

                return book;

            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<IEnumerable<Book>> FindByTitle(string title)
        {
            try
            {
                var books = await _context.Books
                    .Where(c => c.Title.Contains(title))
                    .Include(d => d.Category)
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
