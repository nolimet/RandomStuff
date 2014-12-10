using UnityEngine;
using System.Collections;

public class VertexEditor : MonoBehaviour {

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector2[] uvs = new Vector2[vertices.Length];
        int i = 0;
        while (i < uvs.Length)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
            i++;
        }
        mesh.uv = uvs;
    }
}
