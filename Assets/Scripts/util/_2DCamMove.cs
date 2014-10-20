using UnityEngine;
using System.Collections;

public class _2DCamMove : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private int MaxSizeView = 20, MinSizeView = 10;

	void Update () {
        transform.position += move();
        mouseWheel();
	}

    Vector3 move()
    {
        Vector3 output = new Vector3();
        output.x = Input.GetAxis("Horizontal") * speed;
        output.y = Input.GetAxis("Vertical") * speed;
        return output;
    }

    void mouseWheel()
    {
        float newSize = Camera.main.orthographicSize + Input.GetAxis("Mouse ScrollWheel");

        if (newSize > MinSizeView && newSize < MaxSizeView)
            Camera.main.orthographicSize = newSize;
    }
}
