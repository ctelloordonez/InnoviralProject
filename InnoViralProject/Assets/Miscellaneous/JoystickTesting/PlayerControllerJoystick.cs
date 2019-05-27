using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerJoystick : MonoBehaviour
{
    public float moveSpeed = 10;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;

        Vector3 moveVec3D = new Vector3(0, moveVec.y, moveVec.x);

        float step = moveSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, moveVec3D, step, 0.0f);

        rb.AddForce(new Vector3(0, moveVec.y, moveVec.x) * moveSpeed);

        transform.rotation = Quaternion.LookRotation(newDir);

        float turn = 180 - Vector3.Angle(transform.forward, Vector3.forward);

        if (turn >= 90)
        {
            turn = turn - 180;
        }

        Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
        rb.MoveRotation(rb.rotation * turnRotation);

    }
}
