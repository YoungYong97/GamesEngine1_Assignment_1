using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject prefab;   
    public static GameObject[] prefabLine = new GameObject[MusicVis.numBand];
    public float prefabScale = 5;
    public bool useBuffer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLine();
    }

    // Update is called once per frame
    void Update()
    {        
        UpdataLine();
    }

    void SpawnLine()
    {
        for (int i = 0; i < MusicVis.numBand; i++)
        {
            GameObject line = (GameObject)Instantiate(prefab);

            line.transform.position = this.transform.position;
            line.transform.parent = this.transform;
            line.transform.position = Vector3.right * i * 1.1f;
            prefabLine[i] = line;
        }
    }
    void UpdataLine()
    {
        for (int i = 0; i < MusicVis.numBand; i++)
        {
            if (prefabLine != null)
            {
                if(useBuffer)
                {
                    prefabLine[i].transform.localScale = Vector3.one + Vector3.up * (MusicVis.bandBuffer[i] * prefabScale);
                }
                if(!useBuffer)
                {
                    prefabLine[i].transform.localScale = Vector3.one + Vector3.up * (MusicVis.freqBand[i] * prefabScale);
                }
            }  
        }
    }
}