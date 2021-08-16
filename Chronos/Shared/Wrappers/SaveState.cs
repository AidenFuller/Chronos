﻿using Chronos.Models;
using Chronos.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chronos.Shared.Wrappers
{
    public class SaveState
    {
        public List<List<TileData>> CourseData { get; set; }
        public Degree Degree;
        public Major Major;
        public int BlocksPerYear { get; set; } = 2;
        public int UnitsPerBlock { get; set; } = 40;
        public List<Course> CompletedCourses { get; set; }
        public AvailableCampus Campus { get; set; };
        public CourseRuntime RuntimeStart { get; set; }

        public void CloneFrom(SaveState state)
        {
            CourseData = state.CourseData;
            Degree = state.Degree;
            Major = state.Major;
            BlocksPerYear = state.BlocksPerYear;
            UnitsPerBlock = state.UnitsPerBlock;
            CompletedCourses = state.CompletedCourses;
            Campus = state.Campus;
            RuntimeStart = state.RuntimeStart;
        }
    }
}
