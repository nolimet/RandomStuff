using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyBase : MonoBehaviour {

    public int MaxStorage = 10;
    public float Storage = 0;
    public int Range=5;
    protected Color NodeColor; 
    protected List<EnergyNode> nodes = new List<EnergyNode>();

    void Start()
    {
        NodeColor = DebugGrid.randomColor();
        renderer.material.color = NodeColor;
    }

    public void GetInRangeNodes()
    {
        Debug.Log("boob");
        nodes=new List<EnergyNode>();
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            if (go.gameObject.tag == EnergyTags.EnergyNode && go != this.gameObject)
            {
                float dist = Vector3.Distance(go.transform.position, transform.position);

                if (dist >= 0 && dist < Range)
                {
                    nodes.Add(go.gameObject.GetComponent<EnergyNode>());
                    Debug.Log("addedNode");
                }
                //else if (dist < 0 && dist > Range)
               // {
                 //   nodes.Add(go.gameObject.GetComponent<EnergyNode>());
                //}
            }
        }
    }
    void Update()
    {
        int l = nodes.Count;
        for (int i = 0; i < l; i++)
        {
            Debug.DrawLine(transform.position, nodes[i].transform.position,NodeColor);
        }
    }
}
