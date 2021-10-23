using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Abstract
{
    public interface ICarCommand
    {
        public void TurnLeft();
        public void TurnRight();
        public void Move(MovementFactor movementFactor);
    }
}
