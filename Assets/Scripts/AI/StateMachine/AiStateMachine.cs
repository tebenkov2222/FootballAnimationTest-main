using Core;
using Infrastructure.StateMachine;

namespace AI.StateMachine
{
    public class AiStateMachine : StateMachineBase<AiStateBase>
    {
        public AiStateMachine(IStateFactoryBase stateFactory) : base(stateFactory)
        {
        }

        public void Update()
        {
            _currentState?.UpdateState();
        }

        protected override void MoveToStateBody<TState>(TState newState)
        {
            newState.Init(this);
        }
    }
}