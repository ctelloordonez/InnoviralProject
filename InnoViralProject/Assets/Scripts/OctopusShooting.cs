using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusShooting : MonoBehaviour
{
    public Transform[] ShootingPoints;

    Enemy enemy;

    Transform target;
    float timeToReachTarget;
    float t;
    float shots;
    Vector3 startPosition;

    public float VulnerableTime;

    bool isVulnerable, isShooting;
    float restingTime;

    public Rigidbody plasticProjectile;
    public Transform ShootingSpot;
    public float shootCooldown;
    public float shootSpeed;

    float timeShot;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy.enabled = false;

        startPosition = transform.position;
        timeShot = shootCooldown;
        target = transform;
        shots = 0;
        isVulnerable = false;
        isShooting = true;
    }

    private void Update()
    {
        if (isShooting)
        {
            if(timeShot > 0)
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
            if(restingTime > 0)
            {
                restingTime -= Time.deltaTime;
            }

            else
            {
                isShooting = true;
                isVulnerable = false;
                enemy.enabled = false;
                shots = 0;
            }
        }

        Move();
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
        shots++;
        timeShot = shootCooldown;
        Rigidbody plasticInstance = Instantiate(plasticProjectile, ShootingSpot.position, ShootingSpot.rotation) as Rigidbody;
        plasticInstance.velocity = shootSpeed * ShootingSpot.forward;

        if (shots < 3)
        {
            SetDestination(ShootingPoints[Random.Range(0, 3)], shootCooldown);
        }

        else
        {
            isShooting = false;
            isVulnerable = true;
            enemy.enabled = true;
            restingTime = VulnerableTime;
            SetDestination(ShootingPoints[1], shootCooldown);
        }
    }
}
