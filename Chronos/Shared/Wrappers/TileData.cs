﻿using System;
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
        
        //Returns a list of courses from this tile data
        public List<Course> GetPreReqErrors()
        {
            return ErrorData[ErrorStatus.MissingPrerequisite];
        }

        //Return string of all pre-requisite warnings
        public List<Course> GetPreReqWarnings()
        {
            return ErrorData[ErrorStatus.MissingAssumedKnowledge];
        }

        //Return string of all sibling warnings
        public List<Course> GetSiblingErrors()
        {
            return ErrorData[ErrorStatus.MissingSiblingCourse];
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
