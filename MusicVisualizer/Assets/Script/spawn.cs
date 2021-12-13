using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject prefab;
    public int prefabNum = 512;

    // Start is called before the first frame update
    void Start()
    {
        int radius = (int)((Mathf.PI * 2.0f) / prefabNum);
        float theta = (Mathf.PI * 2.0f) / (float)prefabNum;

        for (int i = 0; i < prefabNum; i++)
        {
            float angle = theta * i;
            float x = Mathf.Sin(angle) * radius * 1.1f;
            float y = Mathf.Cos(angle) * radius * 1.1f;
            GameObject go = GameObject.Instantiate<GameObject>(prefab);
            go.transform.position = transform.TransformPoint
                (new Vector3(x, y, 0));
            go.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < prefabNum; i++)
        {

        }
        
    }
}
