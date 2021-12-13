using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class MusicVis : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] spectrum = new float[128];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
    }
}
