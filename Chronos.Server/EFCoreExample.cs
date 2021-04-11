using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Server
{
    public class EFCoreExample
    {
        public void SampleFunction()
        {
            // always access the DB using this instance
            using AppDbContext dbContext = new AppDbContext();

            dbContext.Courses.Where(i => i.CourseCode == "COMP2270");

            
        }
    }
}
