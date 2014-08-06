using UnityEngine;
using System.Collections;

public class simpleSegmentRotator : MonoBehaviour {

    [SerializeField]
    float DegreesPerSecond = 1f;
    float orignalSpeed;
    int direction = -1;

    float timer = 0f;
    void Start()
    {
        orignalSpeed = DegreesPerSecond;
        DegreesPerSecond = ((DegreesPerSecond*0.25f) * Random.value) + (DegreesPerSecond*0.75f);
    }
	void Update () {
        if (DegreesPerSecond >= orignalSpeed && direction == 1 || DegreesPerSecond <= -orignalSpeed && direction == -1)
            timer += Time.deltaTime;
        else
            DegreesPerSecond += ((orignalSpeed * direction) / 3f)*Time.deltaTime;


        if (timer > 1f)
        {
            timer = 0f;
            direction = direction * -1;
        }

        float step = DegreesPerSecond * Time.deltaTime;
        transform.Rotate(0, 0, step);
       
	}
}
