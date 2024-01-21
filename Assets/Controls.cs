using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controls
{
    //basic movement
    public static KeyCode Forward = KeyCode.W;
    public static KeyCode Back = KeyCode.S;
    public static KeyCode Left = KeyCode.A;
    public static KeyCode Right = KeyCode.D;
    
    //alternative movement
    public static KeyCode MoveToMouse = KeyCode.Mouse0;

    //non movement controls
    public static KeyCode Interact = KeyCode.E;
    public static KeyCode ToggleThrow = KeyCode.Q;
    public static KeyCode Pause = KeyCode.Escape;
    
    //Throw controls
    public static KeyCode Throw = KeyCode.Mouse0;
    //scroll wheel inputs are not keys. scrollDelta is a vector2. .y > 0 : scroll up . .y < 0 : scroll down 

}
