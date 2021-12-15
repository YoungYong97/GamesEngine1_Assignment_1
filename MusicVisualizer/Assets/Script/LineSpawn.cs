using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawn : MonoBehaviour
{

    //decalring variables
    public GameObject prefab;
    public int lineVisual = 8;

    public float visualModifier = 50.0f;
    public float smoothSpeed = 5.0f;
    public float maxVisualScale = 4.0f;
    //percentage of the spectrum to display
    public float keepPercentage = 0.4f;

    private float[] lineVisualScale;
    private Transform[] lineVisualList;

    // Start is called before the first frame update
    void Start()
    {
        //spawn the visuals
        SpawnLine();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLineVisual();
    }

    void SpawnLine()
    {
        //calculating the half way point of the visuals been spawned
        float half = (lineVisual / 2) - 0.5f;
        //initialising the variable as a transform array
        lineVisualList = new Transform[lineVisual];
        //setting the center point to (0, 0, 0)
        Vector3 center = Vector3.zero;

        //for loop to spawn the visuals
        for (int i = 0; i < lineVisual; i++)
        {
            //setting the position of where to spawn the visual
            Vector3 pos = (center + new Vector3(-half + i * 1.1f, -2, 0));
            //creating the visual
            GameObject go = GameObject.Instantiate<GameObject>(prefab);
            //spawning the visual
            go.transform.position = pos;
            //adding the visual to the visual list
            lineVisualList[i] = go.transform;
            go.transform.parent = this.transform;

        }
    }

    void UpdateLineVisual()
    {
        //decalring variable
        lineVisualScale = new float[lineVisual];
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
