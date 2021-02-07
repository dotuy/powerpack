using System;
using System.Collections.Generic;

namespace BlazorState
{
    public class AppState
    {
        readonly Dictionary<Type, object> States = new Dictionary<Type, object>();

        internal T Get<T>() where T : new()
        {
            if (!States.ContainsKey(typeof(T)))
            {
                States.Add(typeof(T), new T());
            }
            var state = States[typeof(T)];
            return (T)state;
        }

        internal void Set<T>(T state)
        {
            States[typeof(T)] = state;
            OnStateUpdated(EventArgs.Empty);
        }

        protected virtual void OnStateUpdated(EventArgs e)
        {
            StateUpdated?.Invoke(this, e);
        }

        public event EventHandler StateUpdated;

    }
}
