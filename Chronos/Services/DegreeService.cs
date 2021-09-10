using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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
            return db.Degrees; //Returns allt he degrees. 
        }

        public async Task<bool> AddDegreeAsync(Degree degree)
        {
            //This will add and save the new Degree in the database. 
            await db.Degrees.AddAsync(degree); 
            await db.SaveChangesAsync();

            return true;
        }

        public async Task RemoveDegreeAsync(Degree degree)
        {
            db.Degrees.Remove(degree);

            var removeCoreCourses = db.CoreCourses.Where(d => d.DegreeID == degree.DegreeID);
            db.CoreCourses.RemoveRange(removeCoreCourses);

            var removeMajors = db.Majors.Where(d => d.DegreeID == degree.DegreeID);
            db.Majors.RemoveRange(removeMajors);

            var removeMajorCourses = db.MajorCourses.Where(d => removeMajors.Any(m => m.MajorID == d.MajorID));
            db.MajorCourses.RemoveRange(removeMajorCourses);

            await db.SaveChangesAsync();
        }

        public async Task<bool> DoesDegreeExist(string degreeName)
        {
            return await Task.FromResult(db.Degrees.Any(d => d.Name == degreeName));
        }
        public async Task<Degree> GetDegreeAsync(int degreeID)
        {
            return await db.Degrees.FindAsync(degreeID); //This will return a specific degree. 
        }

        public async Task<int> GetElectiveUnitsAsync(int degreeID) //Returns the amount of elective units in that degree. 
        {
            Degree degree = await db.Degrees.FindAsync(degreeID);
            return degree.ElectiveUnits;
        }
    }
}
