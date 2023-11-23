using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform LandingPos;

    private float distanceFromPlayer;

    [SerializeField] private float TeleportDistance;
    [SerializeField] private float grappleTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called when player can grapple to point
    void Highlight()
    {
        // run ui shader code 
    }

    void Grapple(Transform Player)
    {
        distanceFromPlayer = Mathf.Abs(transform.position.magnitude - Player.position.magnitude);
        if (distanceFromPlayer <= TeleportDistance)
        {
            Player.position = LandingPos.position;
        }
        else
        {
            //move towards anchor  
        }
    }
}
