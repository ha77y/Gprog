using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : State
{
    private NavMeshAgent _agent;
    private Transform _target;
    private LayerMask _playerLayerMask;
    public EnemyWalkState(NavMeshAgent agent,Transform target)
    {
        _agent = agent;
        _target = target;
        _playerLayerMask = LayerMask.NameToLayer("player");
    }
    public override void Main()
    {
        Collider[] targetsInRadius = Physics.OverlapSphere(_agent.transform.position, 10f,_playerLayerMask);
        
        _agent.destination = _target.position;
        
    }
    
}
