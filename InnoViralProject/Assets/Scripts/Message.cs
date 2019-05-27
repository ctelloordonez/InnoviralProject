using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{

    public GameObject image;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
        text.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Submarine")
        {
            image.SetActive(true);
            text.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Submarine")
        {
            image.SetActive(false);
            text.SetActive(false);
        }
    }
}
