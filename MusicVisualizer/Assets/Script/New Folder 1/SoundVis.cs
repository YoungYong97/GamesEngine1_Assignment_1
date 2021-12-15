using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVis : MonoBehaviour
{
    public static int spectrumSize = 128;

    public float rmsValue;
    public static float dbValue;

    [Range(0, 360)]
    public float speed = 10;

    private AudioSource source;
    private float[] samples;
    public static float[] spectrum;
    private float sampleRate;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        samples = new float[spectrumSize];
        spectrum = new float[spectrumSize];
        sampleRate = AudioSettings.outputSampleRate;
    }    

    // Update is called once per frame
    void Update()
    {
        AnalyzeSound();

        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);

        //Get RMS 
        int i = 0;
        float sum = 0;
        for (i = 0; i < spectrumSize; i++)
        {
            sum = samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / spectrumSize);

        //Get the DB value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //Get sound spectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

    }
}
