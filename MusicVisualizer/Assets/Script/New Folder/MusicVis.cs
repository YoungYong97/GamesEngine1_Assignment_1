using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class MusicVis : MonoBehaviour
{
    AudioSource audioSource;
    public static int numSpectrum = 8192;
    public static float[] spectrum = new float[numSpectrum];
    public static int numBandLine = 8;
    public static int numBandCir = 32;
    public static float[] freqBandLine = new float[numBandLine];
    public static float[] freqBandCir = new float[numBandCir];
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
        int lineCount = 0;
        int cirCount = 0;

        for (int i = 0; i < numBandLine; i++)
        {
            float average = 0;
            int lineSpectrumCount = (int)Mathf.Pow(2, i) * 2;

            if(i == (numBandLine - 1))
            {
                lineSpectrumCount += 2;         
            }

            for (int j = 0; j < lineSpectrumCount; j++)
            {
                average += spectrum[lineCount] * (lineCount);
                lineCount++;
            }
            average /= lineCount;

            freqBandLine[i] = average;
        }


        int cirSpectrumCount = 0;
        for (int i = 0; i < numBandCir; i++)
        {
            float average = 0;
            cirSpectrumCount = cirSpectrumCount + i;

            if (i == (numBandCir - 1))
            {
                cirSpectrumCount -= 16;
            }

            for (int j = 0; j < cirSpectrumCount; j++)
            {
                average += spectrum[cirCount] * (cirCount * 1);
                cirCount++;
            }
            average /= cirCount;

            freqBandCir[i] = average;
        }
    }

    void SmoothBand()
    {

    }
}
