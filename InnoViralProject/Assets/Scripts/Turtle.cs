using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 10;

    Unit unit;
    bool trapped, followSub;
    DialogueTrigger dialogueTrigger;
    Rigidbody m_Rigidbody;
    SphereCollider m_SphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_SphereCollider = GetComponent<SphereCollider>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        trapped = true;
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
        if (followSub && !trapped)
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

    public bool Trapped
    {
        get
        {
            return trapped;
        }
        set
        {
            trapped = value;

            if (trapped)
            {
                m_SphereCollider.enabled = false;
            }
            else
            {
                dialogueTrigger.TriggerDialogue();
                m_SphereCollider.enabled = true;
                if (Vector3.Distance(transform.position, target.position) > 20)
                    followSub = true;
            }

            //unit.enabled = !trapped;
        }
    }
}
