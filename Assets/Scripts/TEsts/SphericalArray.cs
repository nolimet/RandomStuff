using UnityEngine;
using System.Collections;

public class SphericalArray{

    const float PI = Mathf.PI;
	
    public static Vector3[] getArrayLenght(int length, float radius = 10)
    {
        Vector3[] output = new Vector3[length];

        for (int i = 0; i < length; i++)
        {
            output[i] = posSphere(radius, new Vector2(Random.Range(0f, 360f), Random.Range(0f, 360f)));
        }

        return output;
    }

    public static Vector3 posSphere(float Radius, Vector2 Rotation)
    {
        Vector3 output = Vector3.zero;

        Rotation.x = Rotation.x * (PI / 180);
        Rotation.y = Rotation.y * (PI / 180);

        output.x = Radius * Mathf.Cos(Rotation.x) * Mathf.Sin(Rotation.y);
        output.y = Radius * Mathf.Sin(Rotation.x) * Mathf.Sin(Rotation.y);
        output.z = Radius * Mathf.Cos(Rotation.y);
        
        return output; 
    }

   
}
