using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {

    public Transform pointA;
    public Transform pointB;

    public bool direction;

    float startTime;
    float speed = 1f;
    float journeyLength;

    void Start()
    {
        TurnAround();
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        if (direction)
        {
            transform.position = Vector3.Lerp(pointA.position, pointB.position, fracJourney);
        }
        else
        {
            transform.position = Vector3.Lerp(pointB.position, pointA.position, fracJourney);
        }
        if (GetDistance() < 0.1f)
            TurnAround();
    }

    void TurnAround()
    {
        startTime = Time.time;
        direction = !direction;
        journeyLength = GetDistance();
        
    }

    float GetDistance()
    {
        if (direction)
        {
            return Vector3.Distance(transform.position, pointB.position);
        }
        else
        {
            return Vector3.Distance(transform.position, pointA.position);
        }
    }
}
