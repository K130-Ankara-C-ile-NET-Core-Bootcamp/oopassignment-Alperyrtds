using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Abstract
{
    public interface ICollidableSurface
    {
        public bool IsCoordinatesEmpty(Coordinates coordinates);
    }
}
