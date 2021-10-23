using OOPAssignment.Abstract;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Concrete
{
    public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        public CarStringCommandExecutor(ICarCommand carCommand) : base(carCommand)
        {
        }
        public void ExecuteCommand(string commandObject)
        {
            if (string.IsNullOrEmpty(commandObject))
                throw new Exception("Komut Boş geçilemez.");

            
            List<char> orders = commandObject.ToList();
            
            for (int i = 0; i < orders.Count; i++)
            {
                switch (orders[i])
                {
                    case 'L':
                        CarCommand.TurnLeft();
                        break;
                    case 'R':
                        CarCommand.TurnRight();
                        break;
                    case 'M':
                        MovementFactor movementFactory = new();
                        CarCommand.Move(movementFactory);
                        break;
                    default:
                        throw new Exception("Hatalı komut girişi.");
                }
            }
        }
    }
}
