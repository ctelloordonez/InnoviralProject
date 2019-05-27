using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public float speed = 10f;
    public Transform player;

    float step;
    float moveTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        step = Vector3.Distance(transform.position, player.position);
        transform.position = Vector3.MoveTowards(transform.position, player.position, step / moveTime * Time.deltaTime);
    }
}
