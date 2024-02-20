using System;
using Core;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class SimpleAiBot : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Ball _ball;
        [SerializeField] private float _speed;

        private void Awake()
        {
            
        }

        private void Update()
        {
            var direction = (_ball.transform.position - transform.position).normalized;
            _navMeshAgent.Move(direction * Time.deltaTime * _speed);
        }
    }
}