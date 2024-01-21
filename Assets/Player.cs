using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public State currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = gameObject.AddComponent<PlayerWalkState>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Main();

    }
    
}
