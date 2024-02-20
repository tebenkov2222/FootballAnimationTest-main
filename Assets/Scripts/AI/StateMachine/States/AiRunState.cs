using System.Threading.Tasks;
using AI.Constants;
using AI.Core;

namespace AI.StateMachine.States
{
    public class AiRunState : AiStateBase
    {
        public AiRunState(AiBotBase aiBotBase, AiConfig config) : base(aiBotBase, config)
        {
        }

        public override async Task EnterState()
        {
            _aiBotBase.Move.SetMoveSpeed(_config.RunSpeed);
            _aiBotBase.TargetUpdater.SetIsUpdatedFlag(true);
            _aiBotBase.Animator.SetBool(AiConstants.Animator.RUN_STATE, true);
        }

        public override async Task ExitState()
        {
            _aiBotBase.TargetUpdater.SetIsUpdatedFlag(false);
            _aiBotBase.Animator.SetBool(AiConstants.Animator.RUN_STATE, false);
        }

        public override void UpdateState()
        {
            if (_aiBotBase.TargetUpdater.GetDistanceToTarget() <= _config.MinDistanceToIdle) 
                _stateMachine.MoveToState<AiIdleState>();
            if (_aiBotBase.TargetUpdater.GetDistanceToTarget() <= _config.MinDistanceToRun) 
                _stateMachine.MoveToState<AiWalkState>();
        }
    }
}