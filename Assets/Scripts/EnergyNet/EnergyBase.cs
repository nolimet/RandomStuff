using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EnergyNet
{
    public class EnergyBase : MonoBehaviour
    {

        public int MaxStorage = 10;
        public float Storage = 0;
        public int Range = 5;
        public int ID;
        protected Color NodeColor;
        protected List<EnergyNode> nodes = new List<EnergyNode>();

        protected virtual void Start()
        {
            ID = Mathf.FloorToInt(Random.Range(0, 10000000));
            NodeColor = DebugGrid.randomColor();
            renderer.material.color = NodeColor;
        }

        public virtual void GetInRangeNodes(List<EnergyNode>_nodes)
        {
            nodes = new List<EnergyNode>();
            foreach (EnergyNode go in _nodes)
            {
                if (go != this.gameObject)
                {
                    float dist = Vector3.Distance(go.transform.position, transform.position);

                    if (dist >= 0 && dist < Range)
                    {
                        nodes.Add(go.gameObject.GetComponent<EnergyNode>());
                       // Debug.Log("addedNode");
                    }
                    //else if (dist < 0 && dist > Range)
                    // {
                    //   nodes.Add(go.gameObject.GetComponent<EnergyNode>());
                    //}
                }
            }
        }
       public virtual void Update()
        {
            int l = nodes.Count;
            for (int i = 0; i < l; i++)
            {
                Debug.DrawLine(transform.position, nodes[i].transform.position, Color.yellow);
            }
        }
    }
}
