using Infrastructure.StateMachine;

namespace Core
{
    public interface IStateFactoryBase
    {
        public bool TryGetState<TState>(out TState state) where TState : IStateBase;
        public TState GetState<TState>() where TState : IStateBase;
    }
}