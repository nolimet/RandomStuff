using UnityEngine;
using System.Collections;

public class SphericalContaniment : MonoBehaviour
{
    const float PI = Mathf.PI;

    ParticleSystem.Particle[] part = new ParticleSystem.Particle[1000];
    [SerializeField]
    float angle, speed, radius;
    Vector3 o;
    [SerializeField]
    Vector3 offSet;

    void Start()
    {
        o = transform.position;
    }

    private static Vector3 posSphere(float Radius, Vector2 Rotation)
    {
        Vector3 output = Vector3.zero;

        Rotation.x = Rotation.x * (PI / 180);
        Rotation.y = Rotation.y * (PI / 180);

        output.x = Radius * Mathf.Cos(Rotation.x) * Mathf.Sin(Rotation.y);
        output.y = Radius * Mathf.Sin(Rotation.x) * Mathf.Sin(Rotation.y);
        output.z = Radius * Mathf.Cos(Rotation.y);

        return output;
    }

    void Update()
    {
        int l = GetComponent<ParticleSystem>().GetParticles(part);
        float f = 0;
        ParticleSystem.Particle p;
        for (int i = 0; i < l; i++)
        {
            p = part[i];
            f = Vector3.Distance(o, p.position);
            Debug.DrawLine(p.position, p.velocity + p.position);
            if (f > radius)
            {
                if (f > radius + 0.3f)
                    p.position = o;
                p.velocity *= -1 * speed;
            }

            part[i] = p;
        }
        GetComponent<ParticleSystem>().SetParticles(part, l);
    }
}

