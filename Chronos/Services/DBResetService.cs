using Microsoft.EntityFrameworkCore;
using System.Linq;
using Chronos.Models.Enums;
using Chronos.Data;

namespace Chronos.Services
{
    public class DBResetService
    {
        private AppDbContext db;

        public DBResetService(string connectionString)
        {
            db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options);
        }

        ~DBResetService()
        {
            db.Dispose();
        }
               
        public void ClearDB()
        {
            db.Database.Migrate();

            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [CoreCourses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [MajorCourses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Majors]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Courses]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Degrees]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [CourseAvailabilities]");
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE [PrerequisiteCourses]");

            db.SaveChanges();
        }

        public void ResetDB()
        {
            ClearDB();


            #region Degrees
            
            
            #endregion


            #region COMP Courses
            //COMP
            db.Courses.Add(new Models.Course() { CourseCode = "COMP1010", Name = "Computing Fundamentals", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP1140", Name = "Database and Information Management", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2230", Name = "Algorithms", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2240", Name = "Operating Systems", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP2270", Name = "Theory of Computation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3260", Name = "Data Security", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3290", Name = "Compiler Design", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3320", Name = "Computer Graphics", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3330", Name = "Machine Intelligence", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3340", Name = "Data Mining", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3350", Name = "Advanced Database", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3500", Name = "Security Attacks: Analysis and Mitigation Strategies", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3600", Name = "Security Standards and Practices in Industry", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3850", Name = "Computer Science Work Integrated Learning", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851A", Name = "Computer Science and Information Technology Work Integrated Learning Part A", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP3851B", Name = "Computer Science and Information Technology Work Integrated Learning Part B", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4110", Name = "Special Topic A", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4120", Name = "Special Topic B", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4140", Name = "Special Topic D", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4251", Name = "Computing Honours Part 1", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4252", Name = "Computing Honours Part 2", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP4261", Name = "Computing Honours Part 2", Units = 40 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6140", Name = "Databases and Information Management", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6230", Name = "Algorithms", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6240", Name = "Operating Systems", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6270", Name = "Theory of Computation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6290", Name = "Compiler Design", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6340", Name = "Data Mining", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6350", Name = "Advanced Database", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6360", Name = "Data Security", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6370", Name = "Computer Graphics", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6380", Name = "Machine Intelligence", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6500", Name = "Security Attacks: Analysis and Mitigation Strategies", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6600", Name = "Security Standards and Practices in Industry", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "COMP6900", Name = "Computing Project", Units = 20 });

            #endregion

            #region SENG Courses
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1050", Name = "Web Technologies", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1110", Name = "Object Oriented Programming", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG1120", Name = "Data Structures", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2050", Name = "Web Engineering", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2130", Name = "Systems Analysis and Design", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2200", Name = "Programming Languages and Paradigms", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2250", Name = "System and Network Security", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG2260", Name = "Human-Computer Interaction", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3130", Name = "Software Architecture and Quality Management", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3150", Name = "Software Project 1: Requirements Engineering and Design", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3160", Name = "Software Project 2: Software Implementation, Testing, and Maintenance", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3320", Name = "Software Verification and Validation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG3400", Name = "Network and Distributed Computing", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4150", Name = "Special Topics in Software Engineering", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4160", Name = "Directed Studies in Software Engineering", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4211A", Name = "Software Engineering Final Year Project Part A", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4211B", Name = "Software Engineering Final Year Project Part B", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4400", Name = "Enterprise Software Architectures", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4430", Name = "Software Quality", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4800A", Name = "Final Year Software Engineering Project Part A", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG4800B", Name = "Final Year Software Engineering Project Part B", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6050", Name = "Web Engineering", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6051", Name = "Web Technologies", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6110", Name = "Object Oriented Programming", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6120", Name = "Data Structures", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6140", Name = "Software Architecture and Quality Management", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6150", Name = "Software Project 1", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6160", Name = "Software Project 2", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6210A", Name = "Software Engineering Masters Project Part A", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6210B", Name = "Software Engineering Masters Project Part B", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6220", Name = "Programming Languages and Paradigms", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6250", Name = "System and Network Security", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6260", Name = "Human-Computer Interaction", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6320", Name = "Software Verification and Validation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6350", Name = "Systems Analysis and Design", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6400", Name = "Network and Distributed Computing", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6450", Name = "Advanced Special Topics in Software Engineering", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "SENG6460", Name = "Advanced Directed Studies in Software Engineering", Units = 10 });
            #endregion

            #region ENGG Courses
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG1003", Name = "Introduction to Procedural Programming", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG1500", Name = "Introduction to Professional Engineering", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2100", Name = "Engineering Risk and Uncertainty", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2200", Name = "Project/Directed Reading", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2300", Name = "Engineering Fluid Mechanics", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2440", Name = "Modelling and Control", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG2500", Name = "Sustainable Engineering Practice", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3200", Name = "Project/Directed Reading", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3300", Name = "Machine Learning for Engineers", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3440", Name = "Linear Control and Estimation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG3500", Name = "Managing Engineering Projects", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4200", Name = "Project/Directed Reading", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4440", Name = "Nonlinear Control and Estimation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4500", Name = "Engineering Complexity", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4801A", Name = "Engineering Final Year Project A", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG4801B", Name = "Engineering Final Year Project B", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6200", Name = "Project/Directed Reading", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6400", Name = "Modelling and Control", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6440", Name = "Linear Control and Estimation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6441", Name = "Nonlinear Control and Estimation", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6500", Name = "Engineering Complexity", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ENGG6860", Name = "Carbon Accounting and Energy Auditing", Units = 10 });
            #endregion

            #region INFT Courses
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1000", Name = "Information Technology in Business", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1004", Name = "Introduction to Programming", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1150", Name = "Foundations of Information Systems", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT1201", Name = "Digital Technologies for Media and Entertainment", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2012", Name = "Application Programming", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2031", Name = "Systems and Network Administration", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2050", Name = "Mobile Applications and the Cloud", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2051", Name = "Mobile Application Programming", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT2150", Name = "Business Analysis", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3007", Name = "The Information Resource", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3050", Name = "Web Programming", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3100", Name = "Project Management", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3800", Name = "Professional Practice in IT", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3940", Name = "Information Technology Applications", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3950", Name = "Games Design", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT3960", Name = "Games Production", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4000", Name = "Computing Honours: Directed Studies I", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4010", Name = "Computing Honours: Directed Studies II", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4020", Name = "Information Technology Honours III: Research Project", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4030", Name = "Information Technology Honours IV: Research Project", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT4040", Name = "Information Technology Honours V: Research Project", Units = 20 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6009", Name = "Cloud Computing and Mobile Applications for the Enterprise", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6060", Name = "The Digital Economy", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6201", Name = "Big Data", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6304", Name = "Project Planning and Management", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6800", Name = "Professional Practice in IT", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "INFT6900", Name = "Information Technology Project", Units = 20 });
            #endregion

            #region ELEC Courses
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC3500", Name = "Telecommunication Networks", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC1710", Name = "Digital and Computer Electronics 1", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "ELEC2720", Name = "Introduction to Embedded Computing", Units = 10 });
            #endregion

            #region MATH Courses
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1510", Name = "Discrete Mathematics", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH2340", Name = "Linearity and Continuity 1", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1110", Name = "Mathematics for Engineering, Science & Technology 1", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "MATH1120", Name = "Mathematics for Engineering, Science & Technology 2", Units = 10 });
            #endregion

            #region Other Courses
            db.Courses.Add(new Models.Course() { CourseCode = "PSYC6831", Name = "Advanced Research Methods II: Psychological Measurement", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "STAT2300", Name = "Statistical Inference", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "STAT1070", Name = "Statistics For The Sciences", Units = 10});
            db.Courses.Add(new Models.Course() { CourseCode = "JAPN1110", Name = "Elementary Japanese 1", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "JAPN1120", Name = "Elementary Japanese 2", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "JAPN2501", Name = "Japanese In Context 1", Units = 10 });
            db.Courses.Add(new Models.Course() { CourseCode = "JAPN2502", Name = "Japanese In Context 2", Units = 10 });
            #endregion
       
            db.SaveChanges();


            #region COMP CourseAvailability
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP1010"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP1010"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP1010"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP1140"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP1140"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP1140"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP2230"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP2240"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP2270"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3260"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3290"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3320"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3330"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3340"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3350"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3350"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3350"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3600"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3850"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3851A"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1  | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3851A"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3851A"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 | CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3851B"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3851B"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP3851B"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 | CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP4110"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP4120"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP4251"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6140"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6230"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6240"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6290"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6340"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6350"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6360"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6360"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6370"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6380"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6380"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6500"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6600"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("COMP6900"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester2 });
            #endregion

            #region SENG CourseAvailability
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG1050"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG1050"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG1050"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG1110"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG1120"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2050"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2130"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2130"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2130"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2200"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2250"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2260"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2260"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG2260"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG3150"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG3160"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG3320"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG4211A"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG4211B"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG4400"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG4430"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6051"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6110"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6120"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6120"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6210A"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6210B"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6250"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6250"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6260"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6320"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6350"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("SENG6400"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            #endregion

            #region ENGG CourseAvailability
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG1003"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG1003"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 | CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG1500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG1500"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2100"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2100"), Campus = AvailableCampus.SingaporeBCA, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2200"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2300"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2440"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2440"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2500"), Campus = AvailableCampus.SingaporeBCA, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG2500"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG3200"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG3300"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG3500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG3500"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG4200"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG4440"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG4500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG4500"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG4801A"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG4801B"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG6200"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG6400"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG6441"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ENGG6500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            #endregion

            #region INFT CourseAvailability
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT1004"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT1004"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT1004"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT1201"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2012"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2012"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2012"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2031"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2031"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2031"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2031"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2051"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2051"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2051"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2150"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2150"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT2150"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3050"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3050"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3050"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3100"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3100"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3100"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3800"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3800"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3950"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT3960"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT4000"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT4010"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6009"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6009"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6201"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6201"), Campus = AvailableCampus.Sydney, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6201"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6304"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6304"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6304"), Campus = AvailableCampus.Sydney, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6800"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6800"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6800"), Campus = AvailableCampus.Sydney, Runtime = CourseRuntime.Trimester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6900"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6900"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("INFT6900"), Campus = AvailableCampus.Sydney, Runtime = CourseRuntime.Trimester3 });
            #endregion

            #region ELEC CourseAvailability
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ELEC3500"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ELEC1710"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ELEC1710"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 | CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ELEC2720"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("ELEC2720"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester2 });
            #endregion

            #region MATH CourseAvailability
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("MATH1510"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("MATH2340"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("MATH1110"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 | CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("MATH1110"), Campus = AvailableCampus.SingaporeBCA, Runtime = CourseRuntime.Semester2 | CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("MATH1110"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester3 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("MATH1120"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 | CourseRuntime.SummerLS});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("MATH1120"), Campus = AvailableCampus.SingaporePSB, Runtime = CourseRuntime.Trimester1 | CourseRuntime.Trimester3});
            #endregion

            #region Other CourseAvailability
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("PSYC6831"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("PSYC6831"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("STAT2300"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("STAT1070"), Campus = AvailableCampus.Callaghan, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("STAT1070"), Campus = AvailableCampus.Ourimbah, Runtime = CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("JAPN1110"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("JAPN1120"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 | CourseRuntime.Semester2});
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("JAPN2501"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester1 });
            db.CourseAvailabilities.Add(new Models.CourseAvailability() { CourseID = CourseID("JAPN2502"), Campus = AvailableCampus.Online, Runtime = CourseRuntime.Semester2 });
            #endregion

            #region COMP Prerequisite Courses
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG1120"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); //Need to include INFT2012 at some point as it says OR on UON website.
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP2230"), PrerequisiteCourseID = CourseID("SENG1120"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP2230"), PrerequisiteCourseID = CourseID("MATH1510"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP2240"), PrerequisiteCourseID = CourseID("SENG1120"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP2270"), PrerequisiteCourseID = CourseID("SENG1120"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP2270"), PrerequisiteCourseID = CourseID("MATH1510"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG2130"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); 
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG2260"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); //Has ors with INFT (MOST SENG1110s DO)
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG2260"), PrerequisiteCourseID = CourseID("SENG1050"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3851B"), PrerequisiteCourseID = CourseID("COMP3851A"), CourseRequisite = RequisiteType.MustPreceed });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("ELEC3500"), PrerequisiteCourseID = CourseID("COMP2240"), CourseRequisite = RequisiteType.AssumedKnowledge }); //Has ors with ELEC
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("ELEC3500"), PrerequisiteCourseID = CourseID("MATH1510"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT3800"), PrerequisiteCourseID = CourseID("SENG2130"), CourseRequisite = RequisiteType.AssumedKnowledge }); //HAS OR WITH INFT2150
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("MATH1120"), PrerequisiteCourseID = CourseID("MATH1110"), CourseRequisite = RequisiteType.HardRequisite }); //OR with MATH1210
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("ELEC2720"), PrerequisiteCourseID = CourseID("ELEC1710"), CourseRequisite = RequisiteType.AssumedKnowledge });
            //db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("ELEC2720"), PrerequisiteCourseID = CourseID("ENGG1003"), CourseRequisite = RequisiteType.AssumedKnowledge }); Not in the degree plan, but an assumed knowledge?
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3290"), PrerequisiteCourseID = CourseID("SENG1120"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3290"), PrerequisiteCourseID = CourseID("COMP2270"), CourseRequisite = RequisiteType.AssumedKnowledge }); //OR WITH ELEC2700
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG2200"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG2200"), PrerequisiteCourseID = CourseID("SENG1120"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3320"), PrerequisiteCourseID = CourseID("SENG1120"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3320"), PrerequisiteCourseID = CourseID("MATH1110"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3350"), PrerequisiteCourseID = CourseID("COMP1140"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3350"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); //Or with INFT1004
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG3320"), PrerequisiteCourseID = CourseID("SENG2130"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT2150"), PrerequisiteCourseID = CourseID("COMP1010"), CourseRequisite = RequisiteType.AssumedKnowledge }); //On UON, it suggests these courses and having a basic understanding of a thing, it is not ASSUMED like the others but I still put them here. 
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT2150"), PrerequisiteCourseID = CourseID("COMP1140"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG2050"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); //OR WITH INFT1004
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG2050"), PrerequisiteCourseID = CourseID("SENG1050"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3260"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3260"), PrerequisiteCourseID = CourseID("SENG1120"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3260"), PrerequisiteCourseID = CourseID("MATH1510"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT3960"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); //OR WITH INFT1004
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT2031"), PrerequisiteCourseID = CourseID("SENG1050"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3500"), PrerequisiteCourseID = CourseID("COMP2240"), CourseRequisite = RequisiteType.AssumedKnowledge }); //OR WITH INFT2031 OR ELEC2720
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3600"), PrerequisiteCourseID = CourseID("COMP2250"), CourseRequisite = RequisiteType.AssumedKnowledge }); //OR WITH COMP3500
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT2051"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); //OR INFT2012
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3340"), PrerequisiteCourseID = CourseID("MATH1510"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("COMP3340"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT3050"), PrerequisiteCourseID = CourseID("COMP1140"), CourseRequisite = RequisiteType.AssumedKnowledge });
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("INFT3050"), PrerequisiteCourseID = CourseID("SENG1110"), CourseRequisite = RequisiteType.AssumedKnowledge }); //OR INFT2012
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG4430"), PrerequisiteCourseID = CourseID("SENG2130"), CourseRequisite = RequisiteType.AssumedKnowledge });
            #endregion

            //foreach (Models.Course c in db.Courses)
            //{
            //    Console.WriteLine($"{c.CourseCode}, {c.CourseID}");
            //}


            var degree = "Computer Science";
            db.Degrees.Add(new Models.Degree() { InternationalsAllowed = true, Name = degree, UnitLength = 240, ElectiveUnits = 20 });
            db.SaveChanges();

            #region Computer Science Majors
            db.Majors.Add(new Models.Major() { DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID, Name = "Software Development" });
            db.Majors.Add(new Models.Major() { DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID, Name = "Cyber Security" });
            db.Majors.Add(new Models.Major() { DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID, Name = "Computer Systems and Robotics" });
            db.Majors.Add(new Models.Major() { DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID, Name = "Data Science" });
            #endregion

            db.SaveChanges();

            
            #region Computer Science Core Courses
            var coreCourses = new string[]
            {
                "COMP1010", "MATH1110", "SENG1110", "COMP1140", "MATH1510", "SENG1050", "SENG1120", "SENG2130", "COMP2230", "COMP2240", "SENG2250", "SENG2260", "COMP2270", "COMP3851A", "COMP3851B", "ELEC3500"
            };

            foreach (string course in coreCourses)
            {
                db.CoreCourses.Add(new Models.CoreCourse() { CourseID = db.Courses.First(i => i.CourseCode == course).CourseID, DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID });
            }
            #endregion

            #region Computer Science Software Development Courses
            var softwareMajor = "Software Development";
            var directedCoursesSoftwareMajor = new string[]
            {
                "INFT2150", "SENG2050", "COMP3260", "COMP3320", "COMP3350", "INFT3950", "INFT3960"
            };
            var directedCoursesSoftwareCompulsory = new string[]
            {
                "SENG2200", "INFT3100", "SENG3320"
            };

            foreach (string softwareCourseMajor in directedCoursesSoftwareMajor)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == softwareCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == softwareMajor).MajorID, IsCompulsory = false });
            }

            foreach (string softwareCourseMajor in directedCoursesSoftwareCompulsory)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == softwareCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == softwareMajor).MajorID, IsCompulsory = true });
            }
            #endregion

            #region Computer Science Cyber Security Courses
            var securityMajor = "Cyber Security";
            var directedCoursesSecurityMajor = new string[]
            {
                "INFT2051", "COMP3330", "COMP3340", "COMP3350", "INFT3050", "INFT3100", "SENG3320", "SENG4430"
            };
            var directedCoursesSecurityCompulsory = new string[]
            {
                "COMP3260","INFT2031","COMP3500","COMP3600"
            };

            foreach (string securityCourseMajor in directedCoursesSecurityMajor)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == securityCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == securityMajor).MajorID, IsCompulsory = false });
            }

            foreach (string securityCourseMajor in directedCoursesSecurityCompulsory)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == securityCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == securityMajor).MajorID, IsCompulsory = true });
            }
            #endregion

            #region Computer Science Robotics Courses
            var roboticsMajor = "Computer Systems and Robotics";
            var directedCoursesRoboticsMajor = new string[]
            {
                "SENG2200", "COMP3320", "COMP3350"
            };
            var directedCoursesRoboticsCompulsory = new string[]
            {
                "MATH1120", "ELEC1710", "COMP3330", "ELEC2720", "COMP3290"
            };

            foreach (string roboticsCourseMajor in directedCoursesRoboticsMajor)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == roboticsCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == roboticsMajor).MajorID, IsCompulsory = false });
            }

            foreach (string roboticsCourseMajor in directedCoursesRoboticsCompulsory)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == roboticsCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == roboticsMajor).MajorID, IsCompulsory = true });
            }
            #endregion

            #region Computer Science Data Science Courses
            var dataMajor = "Data Science";
            var directedCoursesDataMajor = new string[]
            {
                "COMP3260", "ENGG1003", "MATH2340", "SENG2050"
            };
            var directedCoursesDataCompulsory = new string[]
            {
                "STAT1070", "MATH1120", "COMP3330", "COMP3350", "COMP3340" 
            };

            foreach (string dataCourseMajor in directedCoursesDataMajor)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == dataCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == dataMajor).MajorID, IsCompulsory = false });
            }

            foreach (string dataCourseMajor in directedCoursesDataCompulsory)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == dataCourseMajor).CourseID, MajorID = db.Majors.First(i => i.Name == dataMajor).MajorID, IsCompulsory = true });
            }
            #endregion

            

            degree = "Software Engineering";
            db.Degrees.Add(new Models.Degree() { InternationalsAllowed = false, Name = degree, UnitLength = 320, ElectiveUnits = 20 });
            
            db.SaveChanges();
            
            db.Majors.Add(new Models.Major() { DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID, Name = "Default" });

            

            #region Software Engineering Courses
            coreCourses = new string[]
            {
                "COMP1010", "ENGG1500", "MATH1110", "SENG1110", 
                "COMP1140", "MATH1510", "SENG1050", "SENG1120", 
                "SENG2050", "SENG2130", "SENG2200", 
                "COMP2230", "COMP2240", "SENG2250", "ENGG2500",
                "ENGG3500", "SENG3320", "SENG3150",
                "SENG3160", "ELEC3500", "SENG2260",
                "SENG4400", "SENG4430", "SENG4211A",
                "SENG4211B", "ENGG4500"
            };

            foreach (string course in coreCourses)
            {
                db.CoreCourses.Add(new Models.CoreCourse() { CourseID = db.Courses.First(i => i.CourseCode == course).CourseID, DegreeID = db.Degrees.First(i => i.Name == degree).DegreeID });
            }
            #endregion
            db.SaveChanges();

            var major = "Default";
            var directedCourses = new string[]
            {
                "COMP3260", "COMP3290", "COMP3320", "COMP3330", "COMP3340", "COMP3350", "COMP4110", "COMP4120", "SENG4150", "SENG4160"
            };

            foreach (string course in directedCourses)
            {
                db.MajorCourses.Add(new Models.MajorCourse() { CourseID = db.Courses.First(i => i.CourseCode == course).CourseID, MajorID = db.Majors.First(i => i.Name == major).MajorID, IsCompulsory = false });
            }

            //SENG COURSE AVAILABILITY
            db.PrerequisiteCourses.Add(new Models.PrerequisiteCourse() { CourseID = CourseID("SENG4211B"), PrerequisiteCourseID = CourseID("SENG4211A"), CourseRequisite = RequisiteType.MustPreceed });


            db.SaveChanges();
        }

        private int CourseID(string courseCode) => db.Courses.FirstOrDefault(c => c.CourseCode == courseCode)?.CourseID ?? -1;
    }
}
