using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyAI : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;
    public LayerMask platformPatrol;

    public void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        Ray raycast = new Ray(transform.position, Vector3.down);
        RaycastHit[] groundInfo = Physics.RaycastAll(raycast,distance, platformPatrol);

        if(groundInfo.Length == 0)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distance);
    }
}
