using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusTest : MonoBehaviour
{
    // Patrolling
    public Transform[] ShootingPositions;
    Transform target;
    float timeToReachTarget;
    float t;
    float shots;
    Vector3 startPosition;

    bool vulnerable;
    float restingTime;
    public float vulnerableTime;

    public Rigidbody plasticProjectile;
    public Transform ShootingSpot;
    public float cooldown;
    public float shootSpeed;

    float timeShot;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        timeShot = cooldown;
        target = transform;
        shots = 0;
        vulnerable = false;
        restingTime = vulnerableTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (shots < 3)
        {
            if (timeShot > 0)
            {
                timeShot -= Time.deltaTime;
            }

            else
            {
                Fire();
            }
        }

        else
        {
            vulnerable = true;
            Debug.Log("Hi");
            while (restingTime > 0)
            {
                restingTime -= Time.deltaTime;
                Debug.Log("Trapped");
            }
            restingTime = vulnerableTime;
            vulnerable = false;
            shots = 0;
        }

        if (transform != target)
        {
            Move();
        }

        /*else if(shots >= 3)
        {
            vulnerable = true;
            Debug.Log("Hi");
            while (restingTime > 0)
            {
                restingTime -= Time.deltaTime;
                Debug.Log("Trapped");
            }
            restingTime = vulnerableTime;
            vulnerable = false;
            shots = 0;
        }*/
        else
        {
            Debug.Log("Fck");
        }
    }

    void SetDestination(Transform destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }

    void Move()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target.position, t);
    }

    void Fire()
    {
        if (timeShot <= 0)
        {
            shots++;
            timeShot = cooldown;
            Rigidbody plasticInstance = Instantiate(plasticProjectile, ShootingSpot.position, ShootingSpot.rotation) as Rigidbody;
            plasticInstance.velocity = shootSpeed * ShootingSpot.forward;
            if (shots < 3)
            {
                SetDestination(ShootingPositions[Random.Range(0, 3)], timeShot);
            }
            else
            {
                SetDestination(ShootingPositions[1], cooldown);
            }
        }
    }
}
