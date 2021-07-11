﻿using System.Collections.Generic;
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
            return db.Degrees; //Returns allt he degrees. 
        }

        public async Task<bool> AddDegreeAsync(Degree degree)
        {
            //This will add and save the new Degree in the database. 
            await db.Degrees.AddAsync(degree); 
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Degree> GetDegreeAsync(int degreeID)
        {
            return await db.Degrees.FindAsync(degreeID); //This will return a specific degree. 
        }

        public async Task<int> GetElectiveCountAsync(int degreeID)
        {
            Degree degree = await db.Degrees.FindAsync(degreeID);
            return degree.ElectiveCount;
        }
    }
}
