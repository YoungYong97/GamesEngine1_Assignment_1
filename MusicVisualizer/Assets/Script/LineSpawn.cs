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
    public float keepPercentage = 0.2f;

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
        lineVisualScale = new float[lineVisual];
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
        int lineVisualIndex = 0;
        int lineSpectrumIndex = 0;

        //getting the average size of spectrum that each visual holds
        int lineAverageSize = (int)((SoundVis.spectrumSize / lineVisual) * keepPercentage);

        while (lineVisualIndex < lineVisual)
        {
            int j = 0;
            float sum = 0;
            //calculating the scale of the visual
            while (j < lineAverageSize)
            {
                sum += SoundVis.spectrum[lineSpectrumIndex];
                lineSpectrumIndex++;
                j++;
            }

            float scaleY = sum / lineAverageSize * visualModifier;
            //decreasing the scale of the visual 
            lineVisualScale[lineVisualIndex] -= Time.deltaTime * smoothSpeed;
            //set the scale to the new calculated scale if scale is lower
            if (lineVisualScale[lineVisualIndex] < scaleY)
                lineVisualScale[lineVisualIndex] = scaleY;
            //set the scale to the max scale if the scale is higher than the max scale
            if (lineVisualScale[lineVisualIndex] > maxVisualScale)
                lineVisualScale[lineVisualIndex] = maxVisualScale;
            //change the scale of the visual
            lineVisualList[lineVisualIndex].localScale = Vector3.one + Vector3.up * lineVisualScale[lineVisualIndex];
            lineVisualIndex++;
        }
    }
}
