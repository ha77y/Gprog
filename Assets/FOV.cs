using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FOV : MonoBehaviour
{
   [SerializeField]private float fovAngle;
   [SerializeField]private float lookDistance;
   [SerializeField]private float hearDistance;

   private GameObject _player;
   private Vector3 _dirTowardsPlayer;

   private void Awake()
   {
      _player = GameObject.FindWithTag("Player");
   }

   private void Update()
   {
       _dirTowardsPlayer =  _player.transform.position - transform.position;
       
       //if is in line of sight
       if (Vector3.Angle(transform.forward, _dirTowardsPlayer) < fovAngle / 2)
       {
           // and in range of sight
           if (Physics.Raycast(transform.position, _dirTowardsPlayer, out var hit, lookDistance,
                   LayerMask.NameToLayer("Player")))
           {
               //and isn't behind a wall
               if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Obstacle"))
               {
                   print("i see you");
                   //Chase player ??
                   //or something??
               }

           }
       }
   }

   private void OnDrawGizmos()
   {
       Gizmos.DrawRay(transform.position,_dirTowardsPlayer);
   }
}
