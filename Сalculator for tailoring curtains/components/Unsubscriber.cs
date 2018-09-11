using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    class Unsubscriber<CanvasEntity> : IDisposable
    {
        private List<IObserver<CanvasEntity>> _observers;
        private IObserver<CanvasEntity> _observer;

        internal Unsubscriber(List<IObserver<CanvasEntity>> observers, IObserver<CanvasEntity> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        internal Unsubscriber(IObserver<CanvasEntity> observers, IObserver<CanvasEntity> observer)
        {
            this._observers = new List<IObserver<CanvasEntity>>();
            this._observers.Add(observers);
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
