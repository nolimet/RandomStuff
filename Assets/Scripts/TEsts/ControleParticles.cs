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

    public bool altMode =false, drawDebug = false;
    [SerializeField]
    Vector3[] dir;
    [SerializeField]
    int directions = 10;

    
    void Start()
    {
        dir = new Vector3[directions];

        for (int x = 0; x < directions; x++)
        {
            dir[x] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        int length = 1000;
        for (int i = 0; i < length; i++)
        {
            offSet[i] = Random.Range(0.4f,1f);
        }
    }
    void LateUpdate()
    {
        if (altMode)
            Altmode();
        else
            NormalMode();

        if (drawDebug)
            Debuglines();
    }

    void Altmode()
    {
        Vector3 vel;
        int l = GetComponent<ParticleSystem>().GetParticles(part);
        for (int i = 0; i < l; i++)
        {
            vel = part[i].velocity;
           
            if (vel == Vector3.zero)
            {
                
                vel = dir[Random.Range(0, directions)];
                
                part[i].position = vel * -radius;
                part[i].velocity = vel * speed;
            }
        }

        GetComponent<ParticleSystem>().SetParticles(part, l);
    }

    void NormalMode()
    {
        float rad = (Time.time * speed) * (Mathf.PI / 180); // Converting Degrees To Radians
        //angle += speed * Time.deltaTime;
        Vector3 pos;
        int l = GetComponent<ParticleSystem>().GetParticles(part);
        for (int i = 0; i < l; i++)
        {
            pos = part[i].position;
            pos.x = origin.x + (radius * (part[i].lifetime / 4f) + (5 * offSet[i])) * Mathf.Cos((rad * offSet[i]));
            pos.z = origin.z + (radius * (part[i].lifetime / 4f) + (5 * offSet[i])) * Mathf.Sin((rad * offSet[i]));
            part[i].position = pos;
        }
        GetComponent<ParticleSystem>().SetParticles(part, l);
    }

    void Debuglines()
    {
        for (int i = 1; i < directions; i++)
        {
            if (i % 2 == 0)
                Debug.DrawLine(dir[i - 1] * radius, dir[i] * radius, Color.red);
            else
                Debug.DrawLine(dir[i - 1] * radius, dir[i] * radius, Color.green);
        }
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);
        int l = part.Length;
        for (int i = 0; i < l; i++)
        {
            part[i].velocity = new Vector3(0, 20, 0);
        }
        GetComponent<ParticleSystem>().SetParticles(part, l);
       
    }
}
