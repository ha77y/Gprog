using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Throwable> inventory;
    
    [FormerlySerializedAs("maxInventorySize")]
    [SerializeField] private int capacity;
    [SerializeField] private float scrollCooldown;

    public int Index =0;

    private bool CheckFull()
    {
        //returns true if full
        return inventory.Count >= capacity;
    }
    public void AddToInventory(Throwable newObj)
    {
        if (CheckFull())
        {
            print("inventory is full");
            return;
        }

        newObj.inInventory = true;
        
        inventory.Add(newObj);
    }

    public int CheckCount()
    {
        return inventory.Count;
    }
    
    public void RemoveFromInventory(int pointerPosition)
    {
        Index = 0;
        inventory[pointerPosition].inInventory = false;
        inventory.RemoveAt(pointerPosition);
        
    }

    public void RemoveFromInventory(Throwable obj)
    {
        Index = 0;
        obj.inInventory = false;
        inventory.Remove(obj);
        
    }

    public Throwable GetFromIndex(int index)
    {
        if (inventory.Count == 0)
        {
            return null;
        }
        return inventory[index];
    }
    
    private void FixedUpdate()
    {
        foreach (Throwable item in inventory)
        {
            item.transform.position = transform.position + new Vector3(0, 0, -1*(inventory.IndexOf(item)+1));
        }
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0.5f)
        {
            Index = (Index + 1) % inventory.Count;
            print("item selected : " + inventory[Index]);
            StartCoroutine(Cooldown());

        }else if (Input.mouseScrollDelta.y < -0.5f)
        {
            Index -= 1;
            if (Index < 0)
            {
                Index = inventory.Count - 1;
            }
            print("item selected : " + inventory[Index]);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(scrollCooldown);
    }
}
