using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Make3DCircle : MonoBehaviour
{
    #region Serailized Varibles
    [SerializeField]
	private List<GameObject> parts = new List<GameObject>();
    [SerializeField]
    private Mesh mainMesh;
    [SerializeField]
    private Material mainMaterial;
    [SerializeField]
    private Font mainFont;
    [SerializeField]
    private Material textMaterial;
    [SerializeField]
    private float radius;
    #endregion

    #region Code
    void Start () {
        GameObject g;
        GameObject t;
        GameObject p = new GameObject();
        for (int i = 0; i < 360; i++)
        {
            g = new GameObject();
            t = new GameObject();
            g.name = "line " + i;
            t.name = "text " + i;
            g.transform.parent = p.transform;
            t.transform.parent = g.transform;
            g.AddComponent(typeof(MeshRenderer));
            g.AddComponent(typeof(MeshFilter));
            g.GetComponent<MeshFilter>().mesh = mainMesh;
            g.renderer.material = mainMaterial;

            t.AddComponent(typeof(MeshRenderer));
            t.GetComponent<MeshRenderer>().material = textMaterial;
            t.AddComponent(typeof(TextMesh));
            TextMesh tm = t.GetComponent<TextMesh>();
            tm.fontSize = 110;
            tm.text = i+"°";
            tm.font = mainFont;
            tm.anchor = TextAnchor.MiddleCenter;
            
            g.transform.rotation = Quaternion.Euler(0, 0, i);
            
            if (i % 90 == 0)
            {
                g.transform.localScale = new Vector3(0.02f, radius/2f+0.8f, 0.02f);
                t.transform.localScale = t.transform.localScale / 20f;
                g.transform.Translate(Vector3.up * (radius/2f+0.8f));

            }
            else if (i % 45 == 0)
            {
                g.transform.localScale = new Vector3(0.02f, 0.6f, 0.02f);
                g.transform.Translate(Vector3.up * (radius + 0.3f));
                t.transform.localScale = t.transform.localScale / 40f;
            }
            else
            {
                g.transform.localScale = new Vector3(0.02f, 0.4f, 0.02f);
                g.transform.Translate(Vector3.up * (radius + 0.2f));
                t.transform.localScale = t.transform.localScale / 70f;
            }
            t.transform.localScale = new Vector3(t.transform.localScale.x / g.transform.localScale.x, t.transform.localScale.y / g.transform.localScale.y, t.transform.localScale.z / g.transform.localScale.z);
            t.transform.localPosition = new Vector3(0, 1.1f, 0);
            parts.Add(g);
        }
    }
    #endregion
}
