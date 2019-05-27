using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private InventoryUI inventory;
    public int i;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Submarine").GetComponent<InventoryUI>();
    }


    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpawnItem>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);   
        }
    }
}
