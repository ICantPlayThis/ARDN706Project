using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class ControlLight : MonoBehaviour
{
    // Define objects and components
    public GameObject lightSource;
    public GameObject flame;
    private HDAdditionalLightData lightData;

    // Define values
    private float lightIntensityMax; // maxmimum allowed light intensity
    public float lightIntensityTemp; // intensity value

    public float smoothValue = 0.01f; // value to decrease intensity by

    // Define audio
    public GameObject horrorSource;
    public AudioClip horrorAudio;
    private AudioSource audioComponent;

    private bool playSound = true;

    void Start()
    {
        lightData = lightSource.GetComponent<HDAdditionalLightData>();
        lightIntensityMax = lightData.intensity;
        lightIntensityTemp = lightData.intensity; //temporary value for setting light intensity

        audioComponent = horrorSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (lightIntensityTemp > lightIntensityMax) // check if placeholder intensity is above limit
        {
            lightData.intensity = lightIntensityMax - 1;
            Debug.Log("light intensity above limit. Being lowered.");
        }
        else
            lightData.intensity = lightIntensityTemp;

        if (lightData.intensity >= 0) // if light intensity is above 0, decrease light intensity
            lightData.intensity -= Time.deltaTime * smoothValue;

        if (lightData.intensity == 0) // check if light intensity is equal to 0
        {
            flame.SetActive(false);

            if (playSound) // change audio once
            {
                audioComponent.clip = horrorAudio;
                audioComponent.Play();
                playSound = false;
            }

        }

        lightIntensityTemp = lightData.intensity; // reset temp value
    }
}
