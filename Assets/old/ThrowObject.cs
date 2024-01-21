using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private GameObject[] Inventory;

    public void AddToInventory(GameObject newObject)
    {
        var temp = new GameObject[Inventory.Length + 1];
        temp = Inventory;
        temp[Inventory.Length + 1] = newObject;
        Inventory = new GameObject[Inventory.Length + 1];
        Inventory = temp;
    }

    public void RemoveFromInventory(int position)
    {
        var temp1 = new GameObject[position - 1];
        var temp2 = new GameObject[Inventory.Length - (position+1)];

        for (int i = 0; i < position-1; i++)
        {
            temp1[i] = Inventory[i];
        }

        for (int i = 0; i < Inventory.Length-(position+1); i++)
        {
            temp2[Inventory.Length - i] = Inventory[Inventory.Length - i];
        }

 
    }
}
