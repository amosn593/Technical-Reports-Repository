

using DAL.Data;
using DOMAIN.IRepository;
using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class DirectorateRepo : GenericRepo<Directorate>, IDirectorateRepo
    {
       
        public DirectorateRepo(ReportsDbContext context) : base(context)
        {
            
        }
        
        public async Task<Directorate> FindByName(string name)
        {
            // Get a directorate whose name equals supplied string name
            try
            {
                var directorate = await _context.Directorates.FirstOrDefaultAsync(d => d.Name == name);

                if (directorate == null)
                {
                    
                    throw new NullReferenceException("Directorate with that name is not found");
                }
                return directorate;

            }
            catch (Exception )
            {
                throw;
            }
            
        }
    }
}
