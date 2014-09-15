using UnityEngine;
using System.Collections;

public class SnijLijn : MonoBehaviour {

    GameObject[] points = new GameObject[5];
    [SerializeField]
    Vector3[] pointStartPos = new Vector3[4];

    [SerializeField]
    Mesh pointMesh;

    [SerializeField]
    Material pointMat;
    [SerializeField]
    Material lineMat;

    LineRenderer[] lines = new LineRenderer[2];

    [SerializeField]
    Vector2 stepAB;
    [SerializeField]
    Vector2 stepCD;

    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new GameObject();

           MeshFilter pointMeshFil = points[i].AddComponent<MeshFilter>();
           MeshRenderer pointren = points[i].AddComponent<MeshRenderer>();

           pointMeshFil.mesh = pointMesh;
           pointren.material = pointMat;

           if (i < pointStartPos.Length)
               points[i].transform.position = pointStartPos[i];
            
        }
        for (int j = 0; j < lines.Length; j++) 
        {
            GameObject ln = new GameObject();

            lines[j] = ln.AddComponent<LineRenderer>();
            lines[j].material = lineMat;
            lines[j].useWorldSpace = true;
            lines[j].SetWidth(0.1f, 0.1f);


            if (j == 0)
                ln.name = "lineAB";
            if (j == 1)
                ln.name = "lineCD";
        }

        points[0].name = "pointA";
        points[1].name = "pointB";
        points[2].name = "pointC";
        points[3].name = "pointD";
        points[4].name = "SnijPunt";
        

    }

    void Update()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector3 posSet = points[i].transform.position;
            posSet.z = 0;
            points[i].transform.position = posSet;
        }
        lines[0].SetPosition(0, points[0].transform.position);
        lines[0].SetPosition(1, points[1].transform.position);

        lines[1].SetPosition(0, points[2].transform.position);
        lines[1].SetPosition(1, points[3].transform.position);

        callstep();
    }

    void callstep()
    {
        Vector2 AB = points[0].transform.position - points[1].transform.position;
        float distAB = Mathf.Sqrt((Mathf.Pow(AB.x, 2) + Mathf.Pow(AB.y, 2)));
        stepAB = new Vector2(AB.x / distAB, AB.y / distAB);

        Vector2 CD = points[2].transform.position - points[3].transform.position;
        float distCD = Mathf.Sqrt((Mathf.Pow(CD.x, 2) + Mathf.Pow(CD.y, 2)));
        stepCD = new Vector2(AB.x / distCD, AB.y / distCD);
    }
}
