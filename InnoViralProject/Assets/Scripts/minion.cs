using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion : MonoBehaviour
{
    Enemy enemy;

    bool chase;
    Transform target;
    BoxCollider m_BoxCollider;
    float countDown;

    public float moveSpeed;
    public float lifeTime;
    public float explosionRadius;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy.enabled = false;
        chase = false;
        m_BoxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase)
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Submarine")
        {
            Debug.Log("Collision");
            Destroy(gameObject);
            PlayerHealth.health -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Submarine")
        {
            chase = true;
            enemy.enabled = true;
            target = other.gameObject.transform;
        }
    }
}
