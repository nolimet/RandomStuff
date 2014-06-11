using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
    public float heightScale = 1.0F;
    public float xScale = 1.0F;
    void Update()
    {
        float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0F);
        Vector3 pos = transform.position;
        pos.y = height;
        transform.position = pos;
    }
}
