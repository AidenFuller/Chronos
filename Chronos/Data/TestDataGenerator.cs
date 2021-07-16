using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Chronos.Models.Enums;
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

            // ========= COURSES =========

            //COMP
            db.Courses.Add(new Models.Course() { CourseCode = "COMP1010", Name = "Computing Fundamentals", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP1140", Name = "Database and Information Management", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2230", Name = "Algorithms", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2240", Name = "Operating Systems", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2270", Name = "Theory of Computation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3260", Name = "Data Security", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3290", Name = "Compiler Design", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3320", Name = "Computer Graphics", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3330", Name = "Machine Intelligence", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3340", Name = "Data Mining", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3350", Name = "Advanced Database", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3500", Name = "Security Attacks: Analysis and Mitigation Strategies", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3600", Name = "Security Standards and Practices in Industry", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3850", Name = "Computer Science Work Integrated Learning", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851A", Name = "Computer Science and Information Technology Work Integrated Learning Part A", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851B", Name = "Computer Science and Information Technology Work Integrated Learning Part B", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4110", Name = "Special Topic A", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4120", Name = "Special Topic B", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4140", Name = "Special Topic D", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4251", Name = "Computing Honours Part 1", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4252", Name = "Computing Honours Part 2", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4261", Name = "Computing Honours Part 2", Campus = AvailableCampus.Callaghan, Units = 40, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6140", Name = "Databases and Information Management", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6230", Name = "Algorithms", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6240", Name = "Operating Systems", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6270", Name = "Theory of Computation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6290", Name = "Compiler Design", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6340", Name = "Data Mining", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6350", Name = "Advanced Database", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6360", Name = "Data Security", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6370", Name = "Computer Graphics", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6380", Name = "Machine Intelligence", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6500", Name = "Security Attacks: Analysis and Mitigation Strategies", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6600", Name = "Security Standards and Practices in Industry", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6900", Name = "Computing Project", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });

            //SENG
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1050", Name = "Web Technologies", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1110", Name = "Object Oriented Programming", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1120", Name = "Data Structures", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2050", Name = "Web Engineering", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2130", Name = "Systems Analysis and Design", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2200", Name = "Programming Languages and Paradigms", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2250", Name = "System and Network Security", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2260", Name = "Human-Computer Interaction", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3130", Name = "Software Architecture and Quality Management", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3150", Name = "Software Project 1: Requirements Engineering and Design", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3160", Name = "Software Project 2: Software Implementation, Testing, and Maintenance", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3320", Name = "Software Verification and Validation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3400", Name = "Network and Distributed Computing", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4150", Name = "Special Topics in Software Engineering", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4160", Name = "Directed Studies in Software Engineering", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4211A", Name = "Software Engineering Final Year Project Part A", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4211B", Name = "Software Engineering Final Year Project Part B", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4400", Name = "Enterprise Software Architectures", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4430", Name = "Software Quality", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4800A", Name = "Final Year Software Engineering Project Part A", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4800B", Name = "Final Year Software Engineering Project Part B", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6050", Name = "Web Engineering", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6051", Name = "Web Technologies", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6110", Name = "Object Oriented Programming", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6120", Name = "Data Structures", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6140", Name = "Software Architecture and Quality Management", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6150", Name = "Software Project 1", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6160", Name = "Software Project 2", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6210A", Name = "Software Engineering Masters Project Part A", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6210B", Name = "Software Engineering Masters Project Part B", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6220", Name = "Programming Languages and Paradigms", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6250", Name = "System and Network Security", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6260", Name = "Human-Computer Interaction", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6320", Name = "Software Verification and Validation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6350", Name = "Systems Analysis and Design", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6400", Name = "Network and Distributed Computing", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6450", Name = "Advanced Special Topics in Software Engineering", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6460", Name = "Advanced Directed Studies in Software Engineering", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });

            //ENGG
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG1003", Name = "Introduction to Procedural Programming", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG1500", Name = "Introduction to Professional Engineering", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2100", Name = "Engineering Risk and Uncertainty", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2200", Name = "Project/Directed Reading", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2300", Name = "Engineering Fluid Mechanics", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2440", Name = "Modelling and Control", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2500", Name = "Sustainable Engineering Practice", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3200", Name = "Project/Directed Reading", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3300", Name = "Machine Learning for Engineers", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3440", Name = "Linear Control and Estimation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3500", Name = "Managing Engineering Projects", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4200", Name = "Project/Directed Reading", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4440", Name = "Nonlinear Control and Estimation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4500", Name = "Engineering Complexity", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4801A", Name = "Engineering Final Year Project A", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4801B", Name = "Engineering Final Year Project B", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6200", Name = "Project/Directed Reading", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6400", Name = "Modelling and Control", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6440", Name = "Linear Control and Estimation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6441", Name = "Nonlinear Control and Estimation", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6500", Name = "Engineering Complexity", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6860", Name = "Carbon Accounting and Energy Auditing", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });


            //INFT
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1000", Name = "Information Technology in Business", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1004", Name = "Introduction to Programming", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1150", Name = "Foundations of Information Systems", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1201", Name = "Digital Technologies for Media and Entertainment", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2012", Name = "Application Programming", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2031", Name = "Systems and Network Administration", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2050", Name = "Mobile Applications and the Cloud", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2051", Name = "Mobile Application Programming", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2150", Name = "Business Analysis", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3007", Name = "The Information Resource", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3050", Name = "Web Programming", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3100", Name = "Project Management", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3800", Name = "Professional Practice in IT", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3940", Name = "Information Technology Applications", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3950", Name = "Games Design", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3960", Name = "Games Production", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4000", Name = "Computing Honours: Directed Studies I", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4010", Name = "Computing Honours: Directed Studies II", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4020", Name = "Information Technology Honours III: Research Project", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4030", Name = "Information Technology Honours IV: Research Project", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4040", Name = "Information Technology Honours V: Research Project", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6009", Name = "Cloud Computing and Mobile Applications for the Enterprise", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6060", Name = "The Digital Economy", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6201", Name = "Big Data", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6304", Name = "Project Planning and Management", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6800", Name = "Professional Practice in IT", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6900", Name = "Information Technology Project", Campus = AvailableCampus.Callaghan, Units = 20, Runtime = CourseRuntime.Semester1 });

            db.Courses.Add(new Models.Course() { CourseCode = "PSYC6831", Name = "Advanced Research Methods II: Psychological Measurement", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });
            db.Courses.Add(new Models.Course() { CourseCode = "STAT2300", Name = "Statistical Inference", Campus = AvailableCampus.Callaghan, Units = 10, Runtime = CourseRuntime.Semester1 });

            //ELEC

            //MATH


            //OTHER MISC
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC3500", Name = "Telecommunication Networks", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC1710", Name = "Digital and Computer Electronics 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1510", Name = "Discrete Mathematics", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester2 });

            db.Courses.Add(new Models.Course() { CourseCode = "MATH1110", Name = "Mathematics for Engineering, Science & Technology 1", Campus = Models.Enums.AvailableCampus.Callaghan, Units = 10, Runtime = Models.Enums.CourseRuntime.Semester1 });
            

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
