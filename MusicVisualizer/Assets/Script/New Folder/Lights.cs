using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public int band;
    public float minLight, maxLight;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = (MusicVis.audioBandBuffer[band] * (maxLight - minLight) + minLight);
    }
}
