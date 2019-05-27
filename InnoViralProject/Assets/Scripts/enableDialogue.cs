using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableDialogue : MonoBehaviour
{
    public GameObject octopusDialogue;

    // Start is called before the first frame update
    void Start()
    {
        octopusDialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Submarine")
        {
            octopusDialogue.SetActive(true);
        }
    }
}
