using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public float lightIntensity = 0.5f;
    private float lightIntensityMin = 0.001f;
    private float lightIntensityMax = 1f;

    private Light lightRef;
    private float newLightIntensity;
    private float timer;
    private float randomTime;
    private int counter = 0;
    private float timeMin = 1;
    private float timeMax = 3;

    // Start is called before the first frame update
    private void Start()
    {
        lightRef = GetComponent<Light>();
        randomTime = Random.Range(timeMin,timeMax);
    }

    private void FixedUpdate()
    {
        /*if(lightIntensity < newLightIntensity)
        {
            light.intensity += 0.01f;
        }
        else if(lightIntensity > newLightIntensity)
        {
            light.intensity -= 0.01f;
        }
        else
        {
            newLightIntensity = Random.Range(lightIntensityMin, lightIntensityMax);
        }*/
        lightIntensity = lightRef.intensity;
        switch (counter)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= randomTime)
                {
                    //float x = Random.Range(lightIntensityMin, lightIntensityMax);
                    newLightIntensity = Random.Range(lightIntensityMin, lightIntensityMax);
                    //light.intensity = newLightIntensity;
                    timer = 0;
                    counter = 1;
                    randomTime = Random.Range(timeMin,timeMax);
                }
                break;
            case 1:
                if(System.Math.Abs(lightIntensity % newLightIntensity) < 0.01f)
                {
                    counter = 0;
                }
                if (lightIntensity < newLightIntensity)
                {
                    lightRef.intensity += 0.01f;
                }
                else if (lightIntensity > newLightIntensity)
                {
                    lightRef.intensity -= 0.01f;
                }
                break;
        }

        
    }
}
