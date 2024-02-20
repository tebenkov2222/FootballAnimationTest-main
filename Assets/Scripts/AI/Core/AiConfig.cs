using System;
using UnityEngine;

namespace AI.Core
{
    [Serializable]
    public class AiConfig
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [Space]
        [SerializeField] private float _minDistanceToIdle = 0.2f;
        [SerializeField] private float _minDistanceToRun = 2f;

        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float MinDistanceToIdle => _minDistanceToIdle;
        public float MinDistanceToRun => _minDistanceToRun;
    }
}