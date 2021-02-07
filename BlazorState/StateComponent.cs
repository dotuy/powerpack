using Microsoft.AspNetCore.Components;
using System;

namespace BlazorState
{
    public class StateComponent : ComponentBase
    {
        [Inject] public AppState AppState { get; set; }
    }

    public class StateComponent<T> : StateComponent, IDisposable where T : new()
    {
        public T State { get { return AppState.Get<T>(); } }

        public void SetState(T state)
        {
            AppState.Set(state);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                AppState.StateUpdated += Refresh;
            }
        }

        private void Refresh(object sender, EventArgs e)
        {
            Console.WriteLine("state has changed"); StateHasChanged();
        }

        public void Dispose()
        {
            AppState.StateUpdated -= Refresh;

        }
    }
}
