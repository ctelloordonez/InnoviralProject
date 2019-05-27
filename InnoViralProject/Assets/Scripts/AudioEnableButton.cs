using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnableButton : MonoBehaviour
{
    public GameObject music;

    public GameObject muteButton;

    public GameObject audioButton;


    private void Start()
    {
        muteButton.SetActive(false);
        audioButton.SetActive(true);
    }

    public void Use()
    {
        music.SetActive(true);
        muteButton.SetActive(false);
        audioButton.SetActive(true);
    }
}
