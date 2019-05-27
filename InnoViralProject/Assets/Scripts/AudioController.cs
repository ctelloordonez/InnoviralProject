using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioController : MonoBehaviour
{
    public GameObject music;

    public GameObject muteButton;

    public GameObject audioButton;


    private void Start()
    {
       // muteButton.SetActive(false);
        //audioButton.SetActive(true);
    }

    public void Use()
    {
        music.SetActive(false);
        muteButton.SetActive(true);
        audioButton.SetActive(false);
    }


}
