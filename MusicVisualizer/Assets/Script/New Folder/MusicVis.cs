using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class MusicVis : MonoBehaviour
{
    AudioSource audioSource;
    public static int numSpectrum = 512;
    public static int numBand = 8;
    public static float[] spectrum = new float[numSpectrum];    
    public static float[] freqBand = new float[numBand];
    public static float[] bandBuffer = new float[numBand];
    float[] bufferDecrease = new float[numBand];

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
        BandBuffer();
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

            if(i == (numBand - 1))
            {
                spectrumCount += 2;         
            }

            for (int j = 0; j < spectrumCount; j++)
            {
                average += spectrum[count] * (count + 1);
                count++;
            }
            average /= count;

            freqBand[i] = average;
        }        
    }

    void BandBuffer()
    {
        for (int i = 0; i < numBand; i++)
        {
            if(freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecrease[i] = 0.00005f;
            }

            if (freqBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.1f;
            }
        }
    }
}
