using OOPAssignment.Abstract;
using OOPAssignment.Enums;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Concrete
{
    public class Car : ICarCommand, Abstract.IObservable<CarInfo>
    {
        public Guid Id { get; }
        public Coordinates Coordinates;
        public Direction Direction;
        public ISurface Surface;

        private Abstract.IObserver<CarInfo> Observer { get; set; }

        private Direction[] directions = new Direction[] { Direction.N, Direction.E, Direction.S, Direction.W };

        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Id = Guid.NewGuid();
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }

        public void Attach(Abstract.IObserver<CarInfo> observer)
        {
            Observer = observer;
            Notify();
        }

        public void Notify()
        {
            Coordinates coordinates = new() { X = Coordinates.X, Y = Coordinates.Y };
            CarInfo _info = new CarInfo(Id, coordinates);
            Observer.Update(_info);
        }

        public void TurnLeft()
        {
            var wayIndex = Array.IndexOf(directions, Direction);

            if (--wayIndex < 0)
                wayIndex = 3;

            Direction = directions[wayIndex];
        }

        public void TurnRight()
        {
            var wayIndex = Array.IndexOf(directions, Direction);

            if (++wayIndex > 4)
                wayIndex = 0;

            Direction = directions[wayIndex];
        }

        public void Move(MovementFactor movementFactor)
        {
            movementFactor = new() { XFactor = (int)Coordinates.X, YFactor = (int)Coordinates.Y };

            
            if (Direction == Direction.N)
            {
                movementFactor.YFactor++;
            }
            else if (Direction == Direction.S) 
            {
                movementFactor.YFactor--;
                
            }
            else if (Direction == Direction.W) 
            { 
                movementFactor.XFactor--;

            }
            else if (Direction == Direction.E) 
            {

                movementFactor.XFactor++;
            }
            else
            {
                throw new Exception("İşlem Başarısız.");
            }

            Coordinates = new Coordinates { X = movementFactor.XFactor, Y = movementFactor.YFactor };

            Notify();
        }
    }
}
