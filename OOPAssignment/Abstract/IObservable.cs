using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Abstract
{
    public interface IObservable<T>
    {
        public void Attach(IObserver<T> observer);
        public void Notify();
    }
}
