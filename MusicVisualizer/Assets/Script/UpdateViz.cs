using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateViz : MonoBehaviour
{
    public float prefabScale = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCircle();
        UpdataLine();
    }

    void UpdateCircle()
    {
        for (int i = 0; i < MusicVis.numSpectrum; i++)
        {
            if (spawn.prefabCircle != null)
            {
                spawn.prefabCircle[i].transform.localScale = new Vector3(1, (MusicVis.spectrum[i] * prefabScale), 1);
            }
        }

    }

    void UpdataLine()
    {
        for (int i = 0; i < MusicVis.numBand; i++)
        {
            if (spawn.prefabLine != null)
            {
                spawn.prefabLine[i].transform.localScale = new Vector3(1, (MusicVis.freqBand[i] * prefabScale), 1);
            }
        }
    }
}
