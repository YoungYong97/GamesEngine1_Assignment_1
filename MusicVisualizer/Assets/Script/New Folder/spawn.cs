using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject prefab;
    public static GameObject[] prefabCircle = new GameObject[MusicVis.numBandCir];
    public static GameObject[] prefabLine = new GameObject[MusicVis.numBandLine];
    public float prefabScale = 5;
    public float smoothSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCircle();
        SpawnLine();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCircle();
        UpdataLine();

    }

    void SpawnCircle()
    {
        Vector3 center = Vector3.zero;
        float radius = (float)MusicVis.numBandCir / (Mathf.PI * 2.0f);

        for (int i = 0; i < MusicVis.numBandCir; i++)
        {
            float angle = i * 1.0f / (float)MusicVis.numBandCir;
            angle = angle * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(angle) * radius;
            float y = center.y + Mathf.Sin(angle) * radius;

            Vector3 pos = center + new Vector3(x, y, 0);
            GameObject cir = (GameObject)Instantiate(prefab);

            cir.transform.position = this.transform.position;
            cir.transform.parent = this.transform;
            cir.transform.position = pos;
            cir.transform.rotation = Quaternion.LookRotation(Vector3.forward, pos);
            
            prefabCircle[i] = cir;
        }
    }

    void SpawnLine()
    {
        for (int i = 0; i < MusicVis.numBandLine; i++)
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
        for (int i = 0; i < MusicVis.numBandLine; i++)
        {
            if (prefabLine != null)
            {
                prefabLine[i].transform.localScale = Vector3.one + Vector3.up * MusicVis.freqBandLine[i] * prefabScale;
            }
            
        }
    }

    void UpdateCircle()
    {
        for (int i = 0; i < MusicVis.numBandCir; i++)
        {
            if (prefabCircle != null)
            {
                prefabCircle[i].transform.localScale = Vector3.one + Vector3.up * MusicVis.freqBandCir[i] * prefabScale;
            }
            
        }

    }
}
