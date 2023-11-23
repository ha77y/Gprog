using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 looking;

    private float ComfortableCameraHeight = 1.5f;

    private float currentInputDelay;

    private float inputDelayTime;
    private Transform playerTransform;

    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerTransform.position;
        playerPosition = new Vector3(
            playerPosition.x + Input.GetAxis("Horizontal"),
            playerPosition.y, 
            playerPosition.z + Input.GetAxis("Vertical"));

        playerTransform.position = playerPosition;


        //Camera smooth back to a comfortable position position 
        if (looking.y >= ComfortableCameraHeight && currentInputDelay > inputDelayTime)
        {
            looking = new(looking.x, looking.y - 1f*Time.deltaTime, looking.z);
        }
    }
}
