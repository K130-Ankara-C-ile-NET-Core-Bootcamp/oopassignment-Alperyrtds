using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Abstract
{
    public interface ISurface
    {
        public long Width { get; }
        public long Height { get; }
        public bool IsCoordinatesInBounds(Coordinates coordinates);
    }
}
