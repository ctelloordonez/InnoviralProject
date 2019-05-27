using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damage;


    private void Awake()
    {
        timeBtwAttack  = startTimeBtwAttack;
    }

    private void Update()
    {
        timeBtwAttack -= Time.deltaTime;
    }
    public void MeleeAttack()
    {
        if(timeBtwAttack <= 0)
        {
            Debug.Log("enemytakessmth");
            Collider[] enemiesToDamge = Physics.OverlapSphere(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamge.Length; i++)
            {
                enemiesToDamge[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
