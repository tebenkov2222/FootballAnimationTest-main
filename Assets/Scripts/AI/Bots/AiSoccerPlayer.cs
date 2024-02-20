using System;
using AI.Core;
using AI.StateMachine;
using AI.StateMachine.States;
using Infrastructure.StateMachine;
using Unit;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI
{
    public class AiSoccerPlayer : AiBotBase
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private UnitMove _move;
        [SerializeField] private UnitMoveTargetUpdater _targetUpdater;
        [Space] 
        [SerializeField] private AiConfig _aiConfig;
        
        private AiStateMachine _aiStateMachine;
        
        public override Animator Animator => _animator;
        public override UnitMove Move => _move;
        public override UnitMoveTargetUpdater TargetUpdater => _targetUpdater;

        private void Awake()
        {
            var aiStateMachineFactory = new AiStateMachineFactory(this, _aiConfig);
            _aiStateMachine = new AiStateMachine(aiStateMachineFactory);
            _aiStateMachine.MoveToState<AiIdleState>();
        }

        private void Update()
        {
            _aiStateMachine.Update();
        }
    }
}