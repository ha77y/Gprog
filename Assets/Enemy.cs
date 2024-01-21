using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] Path;
    [SerializeField] private NavMeshAgent Agent;

    private int _currentNode;

    private State _currentState;
    // Start is called before the first frame update
    void Start()
    {
        _currentNode = 0;
        _currentState = new EnemyWalkState(Agent,Path[_currentNode]);
    }

    // Update is called once per frame
    void Update(){

        _currentState.Main();
        
        if (transform.position == Agent.destination)
        {
            _currentNode = (_currentNode + 1) % 4;
            _currentState = new EnemyWalkState(Agent, Path[_currentNode]);
        }

        
    }
}
