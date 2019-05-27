using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 1f;
    public float turnSpeed = 10f;

    Rigidbody m_RigidBody;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    Vector3 movement;

    float previousDistanceToTouchPos; 
    float currentDistanceToTouchPos;
    float turn;
    Quaternion turnRotation;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Debug.DrawLine(transform.position, touchPosition, Color.white);

            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                touchPosition.x = transform.position.x;
                whereToMove = (touchPosition - transform.position).normalized;
                m_RigidBody.velocity = new Vector3(0, whereToMove.y, whereToMove.z).normalized * speed;

                transform.LookAt(touchPosition);

                turn = 180-Vector3.Angle(transform.forward, Vector3.forward);

                if (turn >= 90)
                {
                    turn = turn-180;
                }

                turnRotation = Quaternion.Euler(0f, 0f, turn);
                m_RigidBody.MoveRotation(m_RigidBody.rotation * turnRotation);
                //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y,))

            }
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            m_RigidBody.velocity = Vector3.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
    }

    private void Turn()
    {

    }
}
