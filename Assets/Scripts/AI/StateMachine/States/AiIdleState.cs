using System.Threading.Tasks;
using AI.Core;

namespace AI.StateMachine.States
{
    public class AiIdleState : AiStateBase
    {
        public AiIdleState(AiBotBase aiBotBase, AiConfig config) : base(aiBotBase, config)
        {
        }

        public override async Task EnterState()
        {
            _aiBotBase.Move.Stop();
        }

        public override async Task ExitState()
        {
        }

        public override void UpdateState()
        {
            //todo: вынести эту логику в отдельный контроллер или поменять принцип зависимостей состояний
            if (_aiBotBase.TargetUpdater.GetDistanceToTarget() > _config.MinDistanceToIdle) 
                _stateMachine.MoveToState<AiWalkState>();
            if (_aiBotBase.TargetUpdater.GetDistanceToTarget() > _config.MinDistanceToRun) 
                _stateMachine.MoveToState<AiRunState>();
        }
    }
}