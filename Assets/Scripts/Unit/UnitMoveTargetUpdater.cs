using System;
using UnityEngine;

namespace Unit
{
    public class UnitMoveTargetUpdater : MonoBehaviour
    {
        [SerializeField] private UnitMove _unitMove;
        [SerializeField] private Transform _target;
        [SerializeField] private float _updateSecondsDuration;
        
        private float _lastUpdatedSeconds;
        private bool _isUpdatedFlag;

        private void Update()
        {
            if (_isUpdatedFlag)
                CheckTimer();
        }
        
        public void SetIsUpdatedFlag(bool isUpdatedFlag)
        {
            _isUpdatedFlag = isUpdatedFlag;
        }

        public float GetDistanceToTarget()
        {
            return Vector3.Distance(transform.position, _target.position);
        }

        private void CheckTimer()
        {
            if (Time.time - _lastUpdatedSeconds < _updateSecondsDuration)
            {
                UpdateLastTime();
                UpdateTargetInUnitMove();
            }
        }
        
        private void UpdateTargetInUnitMove()
        {
            _unitMove.MoveTo(_target.position);
        }

        private void UpdateLastTime()
        {
            _lastUpdatedSeconds = Time.time;
        }
    }
}