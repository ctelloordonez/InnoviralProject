using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapped : MonoBehaviour
{
    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade")
        {
            _rigidbody.useGravity = true;
        }
    }
}
