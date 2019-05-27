using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float dazedTime;
    public float startDazedTime;
    public float health;
    float speed;

    void Awake()
    {
        speed = GetComponent<minion>().moveSpeed;
    }

    private void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 5;
        } else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;

        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("works");
        dazedTime = startDazedTime;
        health -= damage;
    }
}
