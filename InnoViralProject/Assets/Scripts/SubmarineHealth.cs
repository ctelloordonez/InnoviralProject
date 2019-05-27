using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineHealth : MonoBehaviour
{
    public static int playerHealth;
    Text health;
    Text submarineHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
        health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = playerHealth.ToString();
        PlayerPrefs.SetInt("submarineHealth", playerHealth);
    }
}
