using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    //decalring variables
    public GameObject prefab;
    public int circleVisual = 32;

    public float visualModifier = 50.0f;
    public float smoothSpeed = 5.0f;
    public float maxVisualScale = 4.0f;
    public float keepPercentage = 0.3f;

    public float backgroundIntensity;
    public Material backgroundMaterial;
    public Color minColor;
    public Color maxColor;
    public float BackgroundSmoothSpeed = 0.5f;

    private float[] cirVisualScale;
    private Transform[] cirVisualList;

    

    // Start is called before the first frame update
    void Start()
    {
        //spawn the visuals
        SpawnCircle();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCirVisual();
        UpdateBackground();
    }

    void SpawnCircle()
    {
        cirVisualScale = new float[circleVisual];
        //initialising the variable as a transform array
        cirVisualList = new Transform[circleVisual];
        //setting the center point to (0, 0, 0)
        Vector3 center = Vector3.zero;
        //setting the radius of the circle
        float radius = 6f;

        for (int i = 0; i < circleVisual; i++)
        {
            //calculating the angle between each visual
            float angle = i * 1.0f / circleVisual;
            angle = angle * Mathf.PI * 2;
            //calculating the x,y of each visual
            float x = center.x + Mathf.Cos(angle) * radius;
            float y = center.y + Mathf.Sin(angle) * radius;
            //setting the position of each visual
            Vector3 pos = center + new Vector3(x, y, 0);
            GameObject go = GameObject.Instantiate<GameObject>(prefab);

            go.transform.position = pos;
            //seeting the direction of each visual
            go.transform.rotation = Quaternion.LookRotation(Vector3.forward, pos);
            cirVisualList[i] = go.transform;
            go.transform.parent = this.transform;
            
        }
    }

    void UpdateCirVisual()
    {
        int cirVisualIndex = 0;
        
        int cirSpectrumIndex = 0;
        
        int cirAverageSize = (int)((SoundVis.spectrumSize / circleVisual) * keepPercentage);
        

        while (cirVisualIndex < circleVisual)
        {
            int j = 0;
            float sum = 0;
            //calculating the scale of the visual
            while (j < cirAverageSize)
            {
                sum += SoundVis.spectrum[cirSpectrumIndex];
                cirSpectrumIndex++;
                j++;
            }

            float scaleY = sum / cirAverageSize * visualModifier;
            //decreasing the scale of the visual 
            cirVisualScale[cirVisualIndex] -= Time.deltaTime * smoothSpeed;
            //set the scale to the new calculated scale if scale is lower
            if (cirVisualScale[cirVisualIndex] < scaleY)
                cirVisualScale[cirVisualIndex] = scaleY;
            //set the scale to the max scale if the scale is higher than the max scale
            if (cirVisualScale[cirVisualIndex] > maxVisualScale)
                cirVisualScale[cirVisualIndex] = maxVisualScale;
            //change the scale of the visual
            cirVisualList[cirVisualIndex].localScale = Vector3.one + Vector3.up * cirVisualScale[cirVisualIndex];
            cirVisualIndex++;
        }

    }

    void UpdateBackground()
    {
        //change the background color based on the db value
        backgroundIntensity -= Time.deltaTime * BackgroundSmoothSpeed;
        if (backgroundIntensity < SoundVis.dbValue / 40)
            backgroundIntensity = SoundVis.dbValue / 40;

        backgroundMaterial.color = Color.Lerp(maxColor, minColor, -backgroundIntensity);
    }
}
