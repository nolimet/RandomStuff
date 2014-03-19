using UnityEngine;
using System.Collections;
namespace EnergyNet
{
    public class EnergyNetWorkControler : MonoBehaviour
    {
        public float CheckForChangesInterval = 1.5f;
        // Use this for initialization
        void Start()
        {
            StartCoroutine("CheckForChanges");
        }
        IEnumerator CheckForChanges()
        {
            while (true)
            {
                Debug.Log("CheckForChanges");
                Object[] objects = FindObjectsOfType(typeof(GameObject));
                foreach (GameObject go in objects)
                {
                    if (go.tag == EnergyTags.EnergyNode)
                    {
                        EnergyNode tmp = go.GetComponent<EnergyNode>();
                        tmp.GetInRangeNodes();
                    }
                }
                yield return new WaitForSeconds(CheckForChangesInterval);
            }
        }
        void Update()
        {

        }
        void OnApplicationStop()
        {
            StopCoroutine("CheckForChanges");
        }
    }
}
