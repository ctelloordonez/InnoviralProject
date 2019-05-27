using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{

    public GameObject trail;

    private void Start()
    {
        trail.SetActive(false);
    }

    public void Use()
    {
        trail.SetActive(!trail.activeSelf);
    }
}
