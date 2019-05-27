using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleFollow : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 10;

    Rigidbody m_Rigidbody;
    bool followSub;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        followSub = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Submarine")
        {
            followSub = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Submarine")
        {
            followSub = true;
        }
    }

    private void FixedUpdate()
    {
        if (followSub)
        {
            transform.LookAt(target);

            float turn = 180 - Vector3.Angle(transform.forward, Vector3.forward);

            if (turn >= 90)
            {
                turn = turn - 180;
            }

            Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
