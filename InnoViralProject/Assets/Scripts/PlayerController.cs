using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 10f;
    public GameObject tapParticlePrefab;

    TouchPhase previousTouchPhase;

    // Move and turn
    Rigidbody m_Rigidbody;
    GameObject currentTapParticle;
    Touch m_Touch;
    Vector3 touchPosition, previousTouchPosition, whereToMove;
    Quaternion turnRotation;
    bool startMoving = false;
    bool isMoving = false;
    float previousDistanceToTouchPos;
    float currentDistanceToTouchPos;
    float turn;

    // Blade
    Blade m_Blade;

    bool isCutting = false;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Blade = GetComponentInChildren<Blade>();

        previousTouchPhase = TouchPhase.Ended;
    }

    void Update()
    {
        if(Time.timeScale == 1)
            TouchManager();

        Move();
    }

    void TouchManager()
    {
        if (Input.touchCount > 0)
        {
            GetTouchPosition();

            if (previousTouchPhase == TouchPhase.Stationary && m_Touch.phase == TouchPhase.Ended && !startMoving)
            {
                Debug.Log("TAP");
                startMoving = true;
            }

            else if(m_Touch.phase == TouchPhase.Moved && !isCutting)
            {
                m_Blade.StartCutting(touchPosition);
                isCutting = true;
                Debug.Log("START CUTTING");
            }

            else if (m_Touch.phase == TouchPhase.Ended && isCutting)
            {
                m_Blade.StopCutting();
                isCutting = false;
                Debug.Log("STOP CUTTING");
            }

            if (isCutting)
            {
                m_Blade.UpdateCut(touchPosition);
                Debug.Log("CUTTING");
            }

            previousTouchPhase = m_Touch.phase;
        }

        else if (isCutting)
        {
            m_Blade.StopCutting();
            isCutting = false;
            Debug.Log("STOP CUTTING");
        }

    }


    void GetTouchPosition()
    {
        m_Touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(m_Touch.position.x, m_Touch.position.y, Camera.main.nearClipPlane));
        touchPosition.x = transform.position.x;
    }

    void Move()
    {
        if (isMoving)
        {
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }

        if (startMoving)
        {
            previousDistanceToTouchPos = 0;
            currentDistanceToTouchPos = 0;
            isMoving = true;

            whereToMove = (touchPosition - transform.position).normalized;
            m_Rigidbody.velocity = new Vector3(0, whereToMove.y, whereToMove.z).normalized * moveSpeed;

            transform.LookAt(touchPosition);
            turn = 180 - Vector3.Angle(transform.forward, Vector3.forward);

            if (turn >= 90)
            {
                turn = turn - 180;
            }

            turnRotation = Quaternion.Euler(0f, 0f, turn);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

            if (currentTapParticle == null)
            {
                currentTapParticle = Instantiate(tapParticlePrefab, touchPosition, (Quaternion.Euler(0, 90, 0)));
                Destroy(currentTapParticle, 3f);
            }
            else
            {
                Destroy(currentTapParticle);
                currentTapParticle = Instantiate(tapParticlePrefab, touchPosition, (Quaternion.Euler(0, 90, 0)));
            }

            startMoving = false;
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            m_Rigidbody.velocity = Vector3.zero;
        }

        if (isMoving)
        {
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }
    }
}
