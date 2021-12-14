using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject prefab;
    public static GameObject[] prefabCircle = new GameObject[MusicVis.numSpectrum];
    public static GameObject[] prefabLine = new GameObject[MusicVis.numBand];
    

    // Start is called before the first frame update
    void Start()
    {
        //SpawnCircle();
        SpawnLine();

    }

    // Update is called once per frame
    void Update()
    {

        UpdateViz.Update();
    }

    void SpawnCircle()
    {
        float angle = 360 / (float)MusicVis.numSpectrum;

        for (int i = 0; i < MusicVis.numSpectrum; i++)
        {
            GameObject cir = (GameObject)Instantiate(prefab);

            cir.transform.position = this.transform.position;
            cir.transform.parent = this.transform;
            this.transform.eulerAngles = new Vector3(0, (angle * i), 0);
            cir.transform.position = Vector3.forward * 100;
            prefabCircle[i] = cir;
        }
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
}
