using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCapsule : MonoBehaviour
{
    public LayerMask m_LayerMask;

    bool m_Started;
    Touch touch;
    Vector3 initialPos, lastPos;
    Ray ray;
    RaycastHit[] hits;

    // Start is called before the first frame update
    void Start()
    {
        m_Started = true;
    }

    private void FixedUpdate()
    {
        MyCollisions();
    }

    void MyCollisions()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                initialPos.x = transform.position.x;
            }

            if(touch.phase == TouchPhase.Moved)
            {
                lastPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                lastPos.x = transform.position.x;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                Vector3 direction = lastPos - initialPos;
                float size = Vector3.Distance(lastPos, initialPos);
                ray = new Ray(initialPos, direction);
                hits = Physics.RaycastAll(ray, size, m_LayerMask);
            }
        }

        if (hits != null) {
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject.tag == "Turtle")
                {
                    Debug.Log("Saved");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (m_Started)
        {
            Gizmos.DrawLine(initialPos, lastPos);
        }
    }
}
