using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Shared.Enums;
using Chronos.Models;
using Chronos.Models.Enums;

namespace Chronos.Shared.Wrappers
{
    public class TileData
    {
        public Course Course { get; set; }
        public ErrorStatus Status { get; set; }
        public TileType TileType { get; set; }
        public CourseRuntime Runtime { get; set; }
        

        public TileData()
        {
            ErrorData = new();
            ErrorData.Add(ErrorStatus.MissingAssumedKnowledge, new List<Course>());
            ErrorData.Add(ErrorStatus.MissingPrerequisite, new List<Course>());
            ErrorData.Add(ErrorStatus.MissingSiblingCourse, new List<Course>());
        }




        //========== ERROR MANAGEMENT ==========
        public Dictionary<ErrorStatus, List<Course>> ErrorData { get; set; }
        
        //Return string of all pre requisite errors
        public string GetPreReqErrors()
        {
            String errors = "";
            if (ErrorData[ErrorStatus.MissingPrerequisite].Count != 0)
            {
                foreach (var course in ErrorData[ErrorStatus.MissingPrerequisite])
                {
                    errors += course.CourseCode + " must be completed before " + Course.CourseCode + "\n";
                }
            }
            return errors;
        }

        //Return string of all pre-requisite warnings
        public string GetPreReqWarnings()
        {
            String errors = "";
            if (ErrorData[ErrorStatus.MissingAssumedKnowledge].Count != 0)
            {
                foreach (var course in ErrorData[ErrorStatus.MissingAssumedKnowledge])
                {
                    errors += course.CourseCode + " should be completed before " + Course.CourseCode + "\n";
                }
            }
            return errors;
        }

        //Return string of all sibling warnings
        public string GetSiblingErrors()
        {
            String errors = "";
            if (ErrorData[ErrorStatus.MissingSiblingCourse].Count != 0)
            {
                foreach (var course in ErrorData[ErrorStatus.MissingSiblingCourse])
                {
                    errors += course.CourseCode + " must be completed the semester before " + Course.CourseCode + "\n";
                }
            }
            return errors;
        }

        public void ClearAllWarnings()
        {
            Status = 0;
            ErrorData[ErrorStatus.MissingAssumedKnowledge].Clear();
            ErrorData[ErrorStatus.MissingPrerequisite].Clear();
            ErrorData[ErrorStatus.MissingSiblingCourse].Clear();
        }

    }
}
