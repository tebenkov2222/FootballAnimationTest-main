using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
    public class UnitMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public void MoveTo(Vector3 pos)
        {
            SetStop(false);
            _navMeshAgent.SetDestination(pos);
        }

        public void SetMoveSpeed(float speed)
        {
            _navMeshAgent.speed = speed;
        }

        public void Stop()
        {
            SetStop(true);
        }

        private void SetStop(bool isStopped)
        {
            _navMeshAgent.isStopped = isStopped;
        }
    }
}