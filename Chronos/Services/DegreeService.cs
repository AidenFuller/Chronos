using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Models;

namespace Chronos.Services
{
    public class DegreeService
    {
        private AppDbContext db;
        public DegreeService(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<IEnumerable<Degree>> GetAllDegreesAsync()
        {
            return db.Degrees;
        }

        public async Task<bool> AddDegreeAsync(Degree degree)
        {
            await db.Degrees.AddAsync(degree);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Degree> GetDegreeAsync(int degreeID)
        {
            return await db.Degrees.FindAsync(degreeID);
        }
    }
}
