using DAL.Data;
using DOMAIN.IRepository;
using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(ReportsDbContext context) : base(context)
        {
        }

        public async Task<Category> FindByName(string name)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(d => d.Name == name);

                if (category == null)
                {

                    throw new NullReferenceException("Category with that name is not found");
                }
                return category;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
