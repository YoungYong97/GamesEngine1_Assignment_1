using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawn : MonoBehaviour
{
    public GameObject prefab;
    public int lineVisual = 8;

    public float visualModifier = 50.0f;
    public float smoothSpeed = 5.0f;
    public float maxVisualScale = 4.0f;
    public float keepPercentage = 0.4f;

    private float[] lineVisualScale;
    private Transform[] lineVisualList;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLine();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLineVisual();
    }

    void SpawnLine()
    {
        float half = (lineVisual / 2) - 0.5f;
        lineVisualScale = new float[lineVisual];
        lineVisualList = new Transform[lineVisual];

        Vector3 center = Vector3.zero;

        for (int i = 0; i < lineVisual; i++)
        {
            Vector3 pos = (center + new Vector3(-half + i * 1.1f, -2, 0));
            GameObject go = GameObject.Instantiate<GameObject>(prefab);
            go.transform.position = pos;
            //go.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
            lineVisualList[i] = go.transform;
            go.transform.parent = this.transform;

        }
    }

    void UpdateLineVisual()
    {
        int lineVisualIndex = 0;
        int lineSpectrumIndex = 0;
        int lineAverageSize = (int)((SoundVis.spectrumSize / lineVisual) * keepPercentage);

        while (lineVisualIndex < lineVisual)
        {
            int j = 0;
            float sum = 0;
            while (j < lineAverageSize)
            {
                sum += SoundVis.spectrum[lineSpectrumIndex];
                lineSpectrumIndex++;
                j++;
            }

            float scaleY = sum / lineAverageSize * visualModifier;
            lineVisualScale[lineVisualIndex] -= Time.deltaTime * smoothSpeed;
            if (lineVisualScale[lineVisualIndex] < scaleY)
                lineVisualScale[lineVisualIndex] = scaleY;

            if (lineVisualScale[lineVisualIndex] > maxVisualScale)
                lineVisualScale[lineVisualIndex] = maxVisualScale;

            lineVisualList[lineVisualIndex].localScale = Vector3.one + Vector3.up * lineVisualScale[lineVisualIndex];
            lineVisualIndex++;
        }
    }
}
