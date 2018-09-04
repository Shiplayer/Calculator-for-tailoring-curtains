using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    class Unsubscriber<CanvasEntityObserver> : IDisposable
    {
        private List<IObserver<CanvasEntityObserver>> _observers;
        private IObserver<CanvasEntityObserver> _observer;

        internal Unsubscriber(List<IObserver<CanvasEntityObserver>> observers, IObserver<CanvasEntityObserver> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
