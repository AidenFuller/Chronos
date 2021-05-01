using Microsoft.AspNetCore.Mvc;
using Chronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data;

namespace Chronos.Services
{
    public class MajorService 
    {
        private AppDbContext db;
        public MajorService(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<bool> AddMajorAsync(Major m)
        {
            await db.Majors.AddAsync(m); //This will add it to the database. 
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Major> GetMajorAsync(int majorID)
        {
            return await db.Majors.FindAsync(majorID);
        }

        public async Task<IEnumerable<Major>> GetMajorsFromDegreeAsync(int degreeID)
        {
            IEnumerable<int> MajorIDs = db.Majors.Where(i => i.DegreeID == degreeID).Select(i => i.MajorID);

            return
              from Major in db.Majors
              join id in MajorIDs on Major.MajorID equals id
              select Major;
        }
    }
}
