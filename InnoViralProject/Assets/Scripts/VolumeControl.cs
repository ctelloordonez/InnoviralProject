using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{

    private AudioSource aSource;

    private float musicVol = 1f;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        aSource.volume = musicVol;
    }

    public void SetVolume(float vol)
    {
        musicVol = vol;
    }
}
