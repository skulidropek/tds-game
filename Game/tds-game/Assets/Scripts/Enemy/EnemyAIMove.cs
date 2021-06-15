using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMove : MonoBehaviour
{
    private Transform _playerPos;
    private NavMeshAgent _agent;

    private void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        _agent = GetComponent <NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        _agent.SetDestination(_playerPos.position);
    }
}
