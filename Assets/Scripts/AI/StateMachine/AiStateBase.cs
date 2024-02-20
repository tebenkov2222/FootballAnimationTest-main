using System.Threading.Tasks;
using AI.Core;
using Infrastructure.StateMachine;

namespace AI.StateMachine
{
    public abstract class AiStateBase : IStateBase
    {
        protected AiBotBase _aiBotBase;
        protected AiConfig _config;
        protected AiStateMachine _stateMachine;

        protected AiStateBase(AiBotBase aiBotBase, AiConfig config)
        {
            _aiBotBase = aiBotBase;
            _config = config;
        }

        public void Init(AiStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public abstract Task EnterState();

        public abstract Task ExitState();
        public abstract void UpdateState();

    }
}