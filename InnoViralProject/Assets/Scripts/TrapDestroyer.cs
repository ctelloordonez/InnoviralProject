using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Submarine")
        {
            Destroy(gameObject, 0.2f);        }
    }
}
