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
    }
}
