using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    public float damage;
    public float minCuttingVelocity = .001f;

    Vector3 previousPosition;
    Vector3 touchPos;

    GameObject currentBladeTrail;

    SphereCollider _sphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Turtle")
        {
            if (other.GetComponent<Turtle>().Trapped)
            {
                other.GetComponent<Turtle>().Trapped = false;
                Debug.Log("Turtle saved");
            }
        }

        else if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy.enabled == true)
            {
               // enemy.TakeDamage();
            }
        }
    }

    public void UpdateCut(Vector3 touchPosition)
    {
        Vector3 newPosition = touchPosition;
        transform.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        _sphereCollider.enabled = velocity > minCuttingVelocity;
        previousPosition = newPosition;
    }

    public void StartCutting(Vector3 touchPosition)
    {
        previousPosition = touchPosition;
        _sphereCollider.enabled = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
    }

    public void StopCutting()
    {
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        _sphereCollider.enabled = false;
        transform.position = Vector3.zero;
    }
}
