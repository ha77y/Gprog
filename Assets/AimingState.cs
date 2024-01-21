using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingState : State 
{
    
    private Inventory _playerInventory;
    private Camera MainCam;
    private Throwable _throwable;
    private bool ThrowObject;
    private bool _switchToWalk = false;
    private float _heightfromThrow;
    private GameObject Arrow;
    private void Awake()
    {
        _playerInventory = gameObject.GetComponent<Inventory>();
        //if (_playerInventory.Index==0)
        //{
        //    SwitchToWalking();
        //}
        
        _heightfromThrow = 5;
        MainCam= Camera.main;
        
        Arrow = transform.GetChild(0).gameObject;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(Controls.Throw))
        {
            ThrowObject = true;
        }

        if (Input.GetKeyDown(Controls.ToggleThrow))
        {
            
            _switchToWalk = true;
        }

    }

    public override void Main()
    {
        if (_playerInventory.CheckCount() == 0)
        {
            SwitchToWalking();
            return;
        }
        _throwable= _playerInventory.GetFromIndex(_playerInventory.Index);
       
       Physics.Raycast(MainCam.ScreenPointToRay(Input.mousePosition),out RaycastHit target);
       Arrow.transform.LookAt(new Vector3(target.point.x,1,target.point.z));
       Arrow.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
       
       


       if (ThrowObject)
       {
           print("thrown object");
           var directionTowardsTarget = transform.position - target.point; 
           
           _playerInventory.RemoveFromInventory(_throwable);
           _throwable.transform.position = gameObject.transform.forward;
           _throwable.GetComponent<Rigidbody>().AddForce((directionTowardsTarget+ Vector3.up*_heightfromThrow)*_throwable.throwForceMultiplier);

           ThrowObject = false;
       }

       if (_switchToWalk)
       {
           print("Button Pressed");
           SwitchToWalking();
       }
    }

    private void SwitchToWalking()
    {
        print("Has Switched to walk");
        gameObject.GetComponent<Player>().currentState = gameObject.AddComponent<PlayerWalkState>();
        Destroy(GetComponent<AimingState>());
    }

   
}
