using OOPAssignment.Abstract;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Concrete
{
    public class Surface : ISurface, ICollidableSurface, Abstract.IObserver<CarInfo>
    {
        public long Width { get; set; }

        public long Height { get; set; }

        private List<CarInfo> ObservableCars = new List<CarInfo>();

        public Surface(long width, long height)
        {
            Width = width;
            Height = height;
        }

        public List<CarInfo> GetObservables()
        {
            List<CarInfo> carInfo = new List<CarInfo>();
            carInfo.AddRange(ObservableCars);
            return carInfo;
        }

        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {
            
            var car = ObservableCars.FirstOrDefault(x => x.Coordinates.X == coordinates.X && x.Coordinates.Y == coordinates.Y);
           
            if (car != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {
           
            bool status = false;
           
            if ((coordinates.X >= 0 && coordinates.X <= Width) && (coordinates.Y >= 0 && coordinates.Y <= Height))
            {
                status = true;

            }

            return status;
        }

        public void Update(CarInfo provider)
        {
            var car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);

            Coordinates coordinates = provider.Coordinates;
           
            if (IsCoordinatesInBounds(coordinates) == false)
            {
                throw new Exception();

            }
           
            if (IsCoordinatesEmpty(coordinates) == false)
            {
                var car1 = ObservableCars
                    .FirstOrDefault(x => x.CarId != provider.CarId
                    && x.Coordinates.X == provider.Coordinates.X
                    && x.Coordinates.Y == provider.Coordinates.Y);

                if (car1 != null)
                    throw new Exception();
            }
          
            else if (car != null)
            {
                car = provider;
            }
            
            else
            {
                ObservableCars.Add(provider);

            }
        
        }
    }
}
