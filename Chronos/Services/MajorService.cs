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
            //This will add it to the database and save it.
            await db.Majors.AddAsync(m); 
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Major> GetMajorAsync(int majorID)
        {
            return await db.Majors.FindAsync(majorID); //This will find the specific MajorID in the Database. 
        }

        public async Task RemoveMajorAsync(Major m)
        {
            db.Majors.Remove(m);

            var removeCourses = db.MajorCourses.Where(c => c.MajorID == m.MajorID);
            db.MajorCourses.RemoveRange(removeCourses);

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Major>> GetMajorsFromDegreeAsync(int degreeID)
        {
            IEnumerable<int> MajorIDs = db.Majors.Where(i => i.DegreeID == degreeID).Select(i => i.MajorID); //Create an IEnumerable of all of the Majors in the Database of Degrees.

            return //Returns all of the majors in the Database by joining the majors based on their ids. 
              from Major in db.Majors
              join id in MajorIDs on Major.MajorID equals id
              select Major;
        }

        public async Task<bool> DoesMajorExist(int degreeID, string name)
        {
            IEnumerable<Major> majors = await GetMajorsFromDegreeAsync(degreeID);
            return majors.Any(c => c.Name == name);
        }
    }
}
