using UnityEngine;
using System.Collections;

public class ControleParticles : MonoBehaviour
{
    ParticleSystem.Particle[] part = new ParticleSystem.Particle[1000];
    [SerializeField]
    float angle, speed,radius;
    [SerializeField]
    Vector3 origin;
    [SerializeField]
    float[] offSet = new float[1000];
    void Start()
    {
        int length = 1000;
        for (int i = 0; i < length; i++)
        {
            offSet[i] = Random.Range(0.4f,1f);
        }
    }
    void LateUpdate()
    {
        
        float rad = (Time.time*speed) * (Mathf.PI / 180); // Converting Degrees To Radians
        //angle += speed * Time.deltaTime;
        Vector3 pos;
        int l = particleSystem.GetParticles(part);
        for (int i = 0; i < l; i++)
        {
            pos = part[i].position;
            pos.x = origin.x + (radius * (part[i].lifetime / 4f) + (5 * offSet[i])) * Mathf.Cos((rad * offSet[i]));
            pos.z = origin.z + (radius * (part[i].lifetime / 4f) + (5 * offSet[i])) * Mathf.Sin((rad * offSet[i]));
            part[i].position = pos;
        }
        particleSystem.SetParticles(part, l);
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);
        int l = part.Length;
        for (int i = 0; i < l; i++)
        {
            part[i].velocity = new Vector3(0, 20, 0);
        }
        particleSystem.SetParticles(part, l);
       
    }
}
