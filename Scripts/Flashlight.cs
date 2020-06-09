using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light spotlight;
    public AudioSource audio;
    public AudioClip soundOn;
    public AudioClip soundOff;

    // Start is called before the first frame update
    void Start()
    {
        spotlight.GetComponent<Light>();
        audio.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(spotlight.enabled == false)
            {
                spotlight.enabled = true;
                audio.clip = soundOn;
                audio.Play();
            }
            else
            {
                spotlight.enabled = false;
                audio.clip = soundOff;
                audio.Play();
            }
        }
    }
}
