using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlastics1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Submarine")
        {
            Destroy(gameObject);
            Score.scoreValue += 1;
            FindObjectOfType<AudioManager>().Play("PlasticCollect");

        }
    }
}
