using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Core;

namespace Infrastructure.StateMachine
{
    public abstract class StateMachineBase <TStateBase> where TStateBase : IStateBase
    {
        protected readonly IStateFactoryBase _stateFactory;
        
        protected TStateBase _currentState = default;
        protected bool _isEnabledCurrentState;
        public IStateFactoryBase StateFactory => _stateFactory;

        public StateMachineBase(IStateFactoryBase stateFactory)
        {
            _stateFactory = stateFactory;
        }
        
        public virtual async void MoveToState<TState>() where TState: TStateBase
        {
            if (!_stateFactory.TryGetState<TState>( out var newState))
            {
                throw new ArgumentOutOfRangeException($"State {typeof(TState)} not found in state machine", typeof(TState).ToString());
            }

            MoveToStateBody(newState);
            SwitchingStates(newState);
        }

        protected abstract void MoveToStateBody<TState>(TState newState) where TState : TStateBase;
        
        private async void SwitchingStates<TState>(TState newState)  where TState: TStateBase
        {
            await ExitOldState<TState>();
            await EnterNewState(newState);
        }

        private async Task ExitOldState<TState>() where TState: TStateBase
        {
            if (_currentState == null) 
                return;
            
            if (_currentState.GetType() == typeof(TState))
                throw new WarningException($"State {typeof(TState)} is already enabled");

            _isEnabledCurrentState = false;
            await _currentState.ExitState();
        }

        private async Task EnterNewState<TState>(TState newState)  where TState: TStateBase
        {
            _currentState = newState;
            await _currentState.EnterState();
            _isEnabledCurrentState = true;
        }
    }
}