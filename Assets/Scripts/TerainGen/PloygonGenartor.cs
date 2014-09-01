﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TerainGen
{
    public class PloygonGenartor : MonoBehaviour
    {
        #region privatevars
        public List<Vector3> newVertices = new List<Vector3>();
        public List<int> newTriangles = new List<int>();
        public List<Vector2> newUV = new List<Vector2>();
        public byte[,] blocks;

        private Mesh mesh;

        private float tUnit = 0.25f;
        private Vector2 tStone = new Vector2(1, 0);
        private Vector2 tGrass = new Vector2(0, 1);

        private int squareCount;
        
        #endregion

        void Start()
        {
            mesh = GetComponent<MeshFilter>().mesh;
            GenTerrain();
            BuildMesh();
            UpdateMesh();

        }

        void UpdateMesh()
        {
            mesh.Clear();
            mesh.vertices = newVertices.ToArray();
            mesh.triangles = newTriangles.ToArray();
            mesh.uv = newUV.ToArray();
            mesh.Optimize();
            mesh.RecalculateNormals();

            squareCount = 0;
            newVertices.Clear();
            newTriangles.Clear();
            newUV.Clear();
        }

        void GenSquare(int x, int y, Vector2 texture)
        {
            newVertices.Add(new Vector3(x, y, 0));
            newVertices.Add(new Vector3(x + 1, y, 0));
            newVertices.Add(new Vector3(x + 1, y - 1, 0));
            newVertices.Add(new Vector3(x, y - 1, 0));

            newTriangles.Add(squareCount * 4);
            newTriangles.Add((squareCount * 4) + 1);
            newTriangles.Add((squareCount * 4) + 3);
            newTriangles.Add((squareCount * 4) + 1);
            newTriangles.Add((squareCount * 4) + 2);
            newTriangles.Add((squareCount * 4) + 3);

            newUV.Add(new Vector2(tUnit * texture.x, tUnit * texture.y + tUnit));
            newUV.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y + tUnit));
            newUV.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y));
            newUV.Add(new Vector2(tUnit * texture.x, tUnit * texture.y));

            squareCount++;
        }

        void GenTerrain()
        {
            blocks = new byte[40, 40];
            
            for (int px = 0; px < blocks.GetLength(0); px++)
            {
                for (int py = 0; py < blocks.GetLength(1); py++)
                {
                    Debug.Log("PY:" + py + " PX:" + px);
                    if (py == 5)
                    {
                        blocks[px, py] = 2;
                    }
                    else if (py < 5)
                    {
                        blocks[px, py] = 1;
                    }
                }
            }
        }

        void BuildMesh()
        {
            for (int px = 0; px < blocks.GetLength(0); px++)
            {
                for (int py = 0; py < blocks.GetLength(1); py++)
                {

                    if (blocks[px, py] == 1)
                    {
                        GenSquare(px, py, tStone);
                    }
                    else if (blocks[px, py] == 2)
                    {
                        GenSquare(px, py, tGrass);
                    }

                }
            }
        }
    }
}
