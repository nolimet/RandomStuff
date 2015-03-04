using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingMEsh : MonoBehaviour {
        /*public Vector3[] newVertices;
        public Vector2[] newUV;
        public int[] newTriangles;
        /void Start()
        {
            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            newVertices = mesh.vertices;
            int l = newVertices.Length;

            for (int i = 0; i < l; i++)
            {
                newVertices[i].y = Random.Range(0F, 2F);
            }
            mesh.vertices = newVertices;
            mesh.uv = newUV;
            mesh.triangles = newTriangles;
        }
	
	// Update is called once per frame
	void Update () {
	
	}*/
    [SerializeField, Range(0f,1f)]
    float scale = 1f;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField, Range(0f, 1f)]
    float noiseStrength = 1f;
    [SerializeField]
    float noiseWalk = 1f;
    private Vector3[] baseHeight;

   

    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        if (baseHeight == null)
            baseHeight = mesh.vertices;
        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        MeshCollider collider = GetComponent<MeshCollider>();
        collider.sharedMesh = null;
        collider.sharedMesh = mesh;
    }
}
