using System;
using System.Collections.Generic;
using AI.Core;
using AI.StateMachine.States;
using Core;
using Infrastructure.StateMachine;

namespace AI.StateMachine
{
    public class AiStateMachineFactory : IStateFactoryBase
    {
        private AiBotBase _aiBotBase;
        private AiConfig _config;
        private Dictionary<Type, IStateBase> _states;

        public AiStateMachineFactory(AiBotBase aiBotBase, AiConfig config)
        {
            _aiBotBase = aiBotBase;
            _config = config;
            _states = new Dictionary<Type, IStateBase>();
            InitStates();
        }

        private void InitStates()
        {
            RegisterState(new AiIdleState(_aiBotBase, _config));
            RegisterState(new AiRunState(_aiBotBase, _config));
            RegisterState(new AiWalkState(_aiBotBase, _config));
        }
        
        private void RegisterState(IStateBase state)
        {
            if (_states.ContainsKey(state.GetType()))
            {
                throw new ArgumentException($"State {state.GetType()} already exist in states", state.GetType().ToString());
            }
            _states.Add(state.GetType(), state);
        }
        
        public bool TryGetState<TState>(out TState state) where TState : IStateBase
        {
            if (!_states.TryGetValue(typeof(TState), out var stateInDict))
            {
                state = default;
                return false;
            }

            state = (TState)stateInDict;
            return true;
        }

        public TState GetState<TState>() where TState : IStateBase
        {
            if (!_states.TryGetValue(typeof(TState), out var stateInDict))
            {
                return default;
            }
            return (TState)stateInDict;
        }
    }
}