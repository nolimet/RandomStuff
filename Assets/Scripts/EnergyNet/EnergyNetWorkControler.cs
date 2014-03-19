using UnityEngine;
using System.Collections;

public class EnergyNetWorkControler : MonoBehaviour {
    public float tickTime = 0.5f;
	// Use this for initialization
	void Start () {
	StartCoroutine("EnergyTick");
	}
    IEnumerator EnergyTick()
    {
        while (true)
        {
            Debug.Log("beeb");
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                if (go.tag == EnergyTags.EnergyNode)
                {
                    EnergyNode tmp = go.GetComponent<EnergyNode>();
                    tmp.GetInRangeNodes();
                }
            }
            yield return new WaitForSeconds(tickTime);
        }
    }
    void OnApplicationStop()
    {
        StopCoroutine("EnergyTick");
    }
}
