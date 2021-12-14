using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class MusicVis : MonoBehaviour
{
    AudioSource audioSource;
    public static int numSpectrum = 512;
    public static float[] spectrum = new float[numSpectrum];
    public static int numBand = 8;
    public static float[] freqBand = new float[numBand];
    public float smoothSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrum();
        GetFreqBands();
    }

    void GetSpectrum()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
    }

    void GetFreqBands()
    {
        int count = 0;

        for (int i = 0; i < numBand; i++)
        {
            float average = 0;
            int spectrumCount = (int)Mathf.Pow(2, i) * 2;

            if(i == 7)
            {
                spectrumCount += 2;         
            }

            for (int j = 0; j < spectrumCount; j++)
            {
                average += spectrum[count] * (count * 1);
                count++;
            }
            average /= count;

            freqBand[i] = average * 10;
        }
    }

    void SmoothBand()
    {

    }
}
