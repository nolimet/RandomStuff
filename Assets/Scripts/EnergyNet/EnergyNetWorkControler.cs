using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EnergyNet
{
    public class EnergyNetWorkControler : MonoBehaviour
    {
        public float CheckForChangesInterval = 1.5f;
        // Use this for initialization
        void Awake()
        {
            StartCoroutine("CheckForChanges");
        }
        IEnumerator CheckForChanges()
        {
            while (true)
            {
                Debug.Log("Update");
                Object[] objects = FindObjectsOfType(typeof(GameObject));
                List<EnergyNode> tmpNodes = new List<EnergyNode>();
                float waitTime = 1f / objects.Length;
                foreach (GameObject go in objects)
                {
                    try
                        {
                    if (go.tag == EnergyTags.EnergyNode)
                    {
                        
                            EnergyNode tmp = go.GetComponent<EnergyNode>();
                            tmp.GetInRangeNodes();
                            tmpNodes.Add(tmp);
                       
                    }
                        }
                    catch (System.Exception e)
                    {
                        Debug.Log(e);
                         }
                    yield return new WaitForSeconds(waitTime);
                }
                foreach (EnergyNode nd in tmpNodes)
                {
                    nd.sendPower();
                }

                yield return new WaitForSeconds(CheckForChangesInterval);
            }
        }
        void OnApplicationStop()
        {
            StopCoroutine("CheckForChanges");
        }
    }
}
