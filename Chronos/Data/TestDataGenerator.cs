using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Data
{
    public class TestDataGenerator
    {
        public static void Setup(string connectionString)
        {
            using var db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options);

            db.Database.Migrate();

            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [CoreCourses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [MajorCourses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Majors]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Courses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Degrees]");

            db.SaveChanges();

            db.Degrees.Add(new Models.Degree() { InternationalsAllowed = true, Name = "Computer Science", UnitLength = 240, ElectiveCount = 2 });
            db.Degrees.Add(new Models.Degree() { InternationalsAllowed = false, Name = "Software Engineering", UnitLength = 360, ElectiveCount = 2 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP1010", Name = "Computing Fundamentals", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1110", Name = "Object Oriented Programming", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1110", Name = "Mathematics for Engineering, Science & Technology 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG1003", Name = "Introduction to Procedural Programming", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP1140", Name = "Database and Information Management", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1510", Name = "Discrete Mathematics", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1050", Name = "Web Technologies", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1120", Name = "Data Structures", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });

            db.Courses.Add(new Models.Course() { CourseCode = "SENG2130", Name = "System Analysis and Design", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2031", Name = "System and Network Adminstration", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3260", Name = "Data Security", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2050", Name = "Web Engineering", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP2230", Name = "Algorithms", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2240", Name = "Operating Systems", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2250", Name = "System and Network Security", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2260", Name = "Human-Computer Interaction", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP2270", Name = "Theory of Computation", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3500", Name = "Security Attacks Analysis and Mitigation Strategies", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851A", Name = "Computer Science Work Integrated Learning Project Part A", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3330", Name = "Machine Intelligence", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });

            db.Courses.Add(new Models.Course() { CourseCode = "COMP3600", Name = "Security Standards and Practices in Industry", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851B", Name = "Computer Science Work Integrated Learning Project Part B", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC3500", Name = "Telecommunication Networks", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC1710", Name = "Digital and Computer Electronics 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });

            db.Courses.Add(new Models.Course() { CourseCode = "SENG2200", Name = "Programming Languages and Paradigms", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3100", Name = "Project Management", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3320", Name = "Software Verification and Validation", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });

            db.Courses.Add(new Models.Course() { CourseCode = "JAPN1110", Name = "Elementary Japanese 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "JAPN1120", Name = "Elementary Japanese 2", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "JAPN2501", Name = "Japanese In Context 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "JAPN2502", Name = "Japanese In Context 2", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.SaveChanges();

            foreach(Models.Course c in db.Courses)
            {
                Console.WriteLine($"{c.CourseCode}, {c.CourseID}");
            }


            db.Majors.Add(new Models.Major() { DegreeID = db.Degrees.First(i => i.Name == "Computer Science").DegreeID, Name = "Software Development" });
            db.Majors.Add(new Models.Major() { DegreeID = db.Degrees.First(i => i.Name == "Computer Science").DegreeID, Name = "Cyber Security" });

            db.SaveChanges();


            // COMPUTER SCIENCE
            var degree = "Computer Science";
            var coreCourses = new string[]
            {
                "COMP1010", "MATH1110", "SENG1110", "COMP1140", "MATH1510", "SENG1050", "SENG1120", "SENG2130", "COMP2230", "COMP2240", "SENG2250", "SENG2260", "COMP2270", "COMP3851A", "COMP3851B", "ELEC3500"
            };

            foreach(string course in coreCourses)
            {
                db.CoreCourses.Add(new Models.CoreCourse() { CourseID = db.Courses.First(i => i.CourseCode == course).CourseID, DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID });
            }

            

            // SOFTWARE DEVELOPMENT MAJOR
            var major = "Software Development";
            var compulsoryCourses = new string[]
            {
                "SENG2200", "INFT3100", "SENG3320"
            };

            var directedCourses = new string[]
            {
                "COMP3260", /*"COMP3320", "COMP3350", "INFT2150", "INFT3950", "INFT3960",*/ "SENG2050"
            };



            foreach(string course in compulsoryCourses)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == course).CourseID, MajorID = db.Majors.First(i => i.Name == major).MajorID, IsCore = true });
            }

            Console.WriteLine("checker");

            foreach (string course in directedCourses)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == course).CourseID, MajorID = db.Majors.First(i => i.Name == major).MajorID});
            }

            db.SaveChanges();



        }
    }
}
