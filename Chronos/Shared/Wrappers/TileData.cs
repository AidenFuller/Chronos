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
        public bool IsDirectedCore { get; set; }
        public CourseRuntime Runtime { get; set; }
        public Dictionary<ErrorStatus, List<Course>> ErrorData { get; set; }

        public TileData()
        {
            ErrorData = new();
            ErrorData.Add(ErrorStatus.MissingAssumedKnowledge, new List<Course>());
            ErrorData.Add(ErrorStatus.MissingPrerequisite, new List<Course>());
            ErrorData.Add(ErrorStatus.MissingSiblingCourse, new List<Course>());
        }
    }
}
