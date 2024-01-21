using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWalkState : State
{
    private NavMeshAgent _agent;
    private bool _switchToAim;

    private void Update()
    {
        if (Input.GetKeyDown(Controls.ToggleThrow))
        {
            print("has switched to aim");
            _switchToAim = true;
        }
    }

    public override void Main()
    {
        Vector2 moving =new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _agent.destination = new Vector3(transform.position.x + moving.x, transform.position.y,
            transform.position.z + moving.y);
        
        if (_switchToAim)
        {
            gameObject.GetComponent<Player>().currentState = gameObject.AddComponent<AimingState>(); 
            Destroy(GetComponent<PlayerWalkState>());
        }
    }

    private void Awake()
    {
        _switchToAim = false;
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }
}
