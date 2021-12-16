using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVis : MonoBehaviour
{
    //declaring variables
    public static int spectrumSize = 256;

    public float rmsValue;
    public static float dbValue;

    [Range(0, 360)]
    public float speed = 10;

    private AudioSource source;
    private float[] samples = new float[spectrumSize];
    public static float[] spectrum = new float[spectrumSize];

    // Start is called before the first frame update
    void Start()
    {
        //getting the type of game object and assigning to source
        source = GetComponent<AudioSource>();
    }    

    // Update is called once per frame
    void Update()
    {
        //calling the AnalyzeSound Function per frame
        AnalyzeSound();
        //rotating the object this script is attached to
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    void AnalyzeSound()
    {
        //getting the output data of the currently playing audio
        source.GetOutputData(samples, 0);

        //calculating the RMS 
        int i = 0;
        float sum = 0;
        for (i = 0; i < spectrumSize; i++)
        {
            sum = samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / spectrumSize);

        //from the rms value calculate the DB value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //Getting the sound spectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

    }
}
