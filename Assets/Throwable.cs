using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    private KeyCode _interactKey;

    public bool inInventory;
    public float throwForceMultiplier = 5;
    private bool _inRange;
    private bool _interacted;
    
    private Collider _itemCollider;
    private Rigidbody _itemRigidbody;
    private Collider[] _colliders;
    private GameObject _player;
    private void Update()
    {
         _colliders= Physics.OverlapSphere(transform.position, pickupRange,LayerMask.GetMask("Player"));
        if (_colliders.Length > 0)
        {
            _inRange = true;
        }
        else
        {
            _inRange = false;
        }

        if (Input.GetKeyDown(_interactKey))
        {
            _interacted = true;
        }
    }

    private void Start()
    {
        _interactKey = Controls.Interact;
        _itemCollider = gameObject.GetComponent<Collider>();
        _itemRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    

    private void FixedUpdate()
    {
        
        switch (inInventory)
        {
            case true: _itemCollider.enabled = false; _itemRigidbody.constraints = RigidbodyConstraints.FreezePositionY ; break;
            case false: _itemCollider.enabled = true; _itemRigidbody.constraints = RigidbodyConstraints.None ; break;
        }
        
        if (_inRange && !inInventory)
        {
            _player = _colliders[0].gameObject;
            print(_player.gameObject.name);

            if (_interacted)
            {
                //Pick up object 
                _player.GetComponent<Inventory>().AddToInventory(this);
                print("Picked up " + gameObject.name);
                
                
            }
        }
        
        _interacted = false;
    }
}
