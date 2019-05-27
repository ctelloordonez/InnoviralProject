using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleStartFollowing : MonoBehaviour
{
    public GameObject turtle;
    TurtleFollow turtleFollow;

    // Start is called before the first frame update
    void Start()
    {
        turtleFollow = turtle.GetComponent<TurtleFollow>();
        turtleFollow.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Submarine")
        {
            turtleFollow.enabled = true;
        }
    }
}
