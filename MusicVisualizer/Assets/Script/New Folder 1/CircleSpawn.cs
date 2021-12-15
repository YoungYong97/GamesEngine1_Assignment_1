using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    public GameObject prefab;
    public int circleVisual = 32;

    public float visualModifier = 50.0f;
    public float smoothSpeed = 5.0f;
    public float maxVisualScale = 5.0f;
    public float keepPercentage = 0.5f;

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
        cirVisualList = new Transform[circleVisual];

        Vector3 center = Vector3.zero;
        float radius = 6f;

        for (int i = 0; i < circleVisual; i++)
        {
            float angle = i * 1.0f / circleVisual;
            angle = angle * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(angle) * radius;
            float y = center.y + Mathf.Sin(angle) * radius;

            Vector3 pos = center + new Vector3(x, y, 0);
            GameObject go = GameObject.Instantiate<GameObject>(prefab);

            go.transform.position = pos;
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
            while (j < cirAverageSize)
            {
                sum += SoundVis.spectrum[cirSpectrumIndex];
                cirSpectrumIndex++;
                j++;
            }

            float scaleY = sum / cirAverageSize * visualModifier;
            cirVisualScale[cirVisualIndex] -= Time.deltaTime * smoothSpeed;
            if (cirVisualScale[cirVisualIndex] < scaleY)
                cirVisualScale[cirVisualIndex] = scaleY;

            if (cirVisualScale[cirVisualIndex] > maxVisualScale)
                cirVisualScale[cirVisualIndex] = maxVisualScale;

            cirVisualList[cirVisualIndex].localScale = Vector3.one + Vector3.up * cirVisualScale[cirVisualIndex];
            cirVisualIndex++;
        }

    }

    void UpdateBackground()
    {
        backgroundIntensity -= Time.deltaTime * BackgroundSmoothSpeed;
        if (backgroundIntensity < SoundVis.dbValue / 40)
            backgroundIntensity = SoundVis.dbValue / 40;

        backgroundMaterial.color = Color.Lerp(maxColor, minColor, -backgroundIntensity);
    }
}
