using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject item;
    private Transform submarine;
    // Start is called before the first frame update
    void Start()
    {
        submarine = GameObject.FindGameObjectWithTag("Submarine").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector3 submarinePos = new Vector3(submarine.position.x, submarine.position.y + 3);
        Instantiate(item, submarinePos, Quaternion.identity);
    }
    
}
