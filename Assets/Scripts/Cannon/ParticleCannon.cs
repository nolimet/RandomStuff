using UnityEngine;
using System.Collections;

public class ParticleCannon : MonoBehaviour {
    bool firing;
    [SerializeField]
    ParticleSystem charginBeam, firingBeam;
	// Use this for initialization
	void Start () {
        firingBeam.emissionRate = 0;
        charginBeam.emissionRate = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
            StartCoroutine(fireCannon());
	}

    IEnumerator fireCannon()
    {
        if (!firing)
        {
            int maxCharge = 120;
            int charge= 0;
            firing = true;
            while (Input.GetKey(KeyCode.C) && charge < maxCharge)
            {
                charge++;
                charginBeam.emissionRate = charge;
                yield return new WaitForSeconds(0.05f);
            }
            charginBeam.emissionRate = 0;
            yield return new WaitForSeconds(4f);
            firingBeam.Emit(charge*2);
            

            firing = false;
        }
    }
}
