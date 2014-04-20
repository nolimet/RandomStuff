using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EnergyNet
{
    public class EnergyNetWorkControler : MonoBehaviour
    {
        
        public float CheckForChangesInterval = 1.5f;
        private float CallculedWaitTime=1f;
        [Range(1, 20)]
        public int TicksPerSecond = 4;

        // Use this for initialization
        void Awake()
        {
            StartCoroutine("CheckForChanges");
        }
        void Update()
        {
            CallculedWaitTime = 1f / TicksPerSecond;
            CheckForChangesInterval = CallculedWaitTime * 0.3f;
        }

        IEnumerator CheckForChanges()
        {
            while (true)
            {  
                Object[] objects = FindObjectsOfType(typeof(GameObject));
                List<EnergyNode> tmpNodes = new List<EnergyNode>();
                List<EnergyGenator> tmpGens = new List<EnergyGenator>();
                float waitTime = CallculedWaitTime / objects.Length;
                foreach (GameObject go in objects)
                {
                    if (go != null)
                    {
                        try
                        {
                            if (go.tag == EnergyTags.EnergyNode)
                            {

                                EnergyNode tmp = go.GetComponent<EnergyNode>();
                                tmpNodes.Add(tmp);

                            }
                            else if (go.tag == EnergyTags.EnergyGenartor)
                            {
                                EnergyGenator tmp = go.GetComponent<EnergyGenator>();
                                tmpGens.Add(tmp);
                            }
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogWarning(e);
                        }
                    }
                    yield return new WaitForSeconds(waitTime);
                }
                foreach (EnergyNode nd in tmpNodes)
                {
                    nd.GetInRangeNodes(tmpNodes);
                    nd.sendPower();
                }

                foreach (EnergyGenator gr in tmpGens)
                {
                    gr.GetInRangeNodes(tmpNodes);
                    gr.sendPower();
                }
                EnergyGlobals.RealTPS = waitTime * objects.Length;
                yield return new WaitForSeconds(CheckForChangesInterval);
            }
        }

        void OnApplicationStop()
        {
            StopCoroutine("CheckForChanges");
        }
    }
}
