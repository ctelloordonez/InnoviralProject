using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSeaMine : MonoBehaviour
{

    private ScreenShake shake;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ScreenShake>();
;    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Submarine")
        {
            shake.CamShake();
            Destroy(gameObject);
            PlayerHealth.health -= 1;
        }
    }
}
