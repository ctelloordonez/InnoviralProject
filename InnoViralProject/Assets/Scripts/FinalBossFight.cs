using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossFight : MonoBehaviour
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
    public float shootCooldown;
    public float shootSpeed;

    float timeShot;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy.enabled = false;

        startPosition = transform.position;
        timeShot = shootCooldown;
        target = ShootingPoints[1];
        shots = 0;
        isVulnerable = false;
        isShooting = true;
    }

    private void Update()
    {
        if (isShooting)
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
            if (restingTime > 0)
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

        Transform firePoint1 = ShootingPoints[Random.Range(0, 3)];
        Transform firePoint2 = ShootingPoints[Random.Range(0, 3)];
        while (firePoint1 == firePoint2)
        {
            firePoint2 = ShootingPoints[Random.Range(0, 3)];
        }

        Rigidbody plasticInstance1 = Instantiate(plasticProjectile, firePoint1.position, firePoint1.rotation) as Rigidbody;
        plasticInstance1.velocity = shootSpeed * firePoint1.forward;

        Rigidbody plasticInstance2 = Instantiate(plasticProjectile, firePoint2.position, firePoint2.rotation) as Rigidbody;
        plasticInstance2.velocity = shootSpeed * firePoint2.forward;

        if (shots < 6)
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
