using UnityEngine;
using System.Collections;

public class MoveVectory : MonoBehaviour {

    bool atHome;
    [SerializeField]
    Vector2 Step;

    [SerializeField]
    Vector2[] points = new Vector2[2];

    [SerializeField]
    Rect currentPos;

    [SerializeField]
    float timePerStep;

    float t;

    void Start()
    {
        currentPos = new Rect(points[0].x, points[0].y, 20, 20);

        Vector2 tus = points[1] - points[0];
        float dist = Mathf.Sqrt((Mathf.Pow(tus.x,2)+Mathf.Pow(tus.y,2)));
        Step = new Vector2(tus.x / dist, tus.y / dist);
    }

    void Update()
    {
        t += Time.deltaTime;

        if (t < timePerStep)
            return;

        t = 0;

        float m = distance();

        if (m > 2)
            currentPos = new Rect(currentPos.xMin + Step.x * 2, currentPos.yMin + Step.y * 2, 20, 20);
        else
            atHome = !atHome;

        
    }

    float distance()
    {
        Vector2 tus;

        if(!atHome)
             tus = points[1] - new Vector2(currentPos.x,currentPos.y);
        else
             tus = points[0] - new Vector2(currentPos.x,currentPos.y);
        float dist = Mathf.Sqrt((Mathf.Pow(tus.x, 2) + Mathf.Pow(tus.y, 2)));

        Step = new Vector2(tus.x / dist, tus.y / dist);
        return dist;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(points[0].x, points[0].y, 20, 20), "o");
        GUI.Label(new Rect(points[1].x, points[1].y, 20, 20), "o");

        GUI.Label(currentPos, ".");
    }
}
