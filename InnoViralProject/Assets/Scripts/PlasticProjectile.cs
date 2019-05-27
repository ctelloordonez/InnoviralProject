using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticProjectile : MonoBehaviour
{
    float lifeTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
