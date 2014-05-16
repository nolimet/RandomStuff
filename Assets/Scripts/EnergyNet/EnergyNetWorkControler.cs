using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EnergyNet
{
    public class EnergyNetWorkControler : MonoBehaviour
    {

        public float CheckForChangesInterval = 1.5f;
        private float CallculedWaitTime = 1f;
        [Range(1, 20)]
        public int TicksPerSecond = 4;
        List<EnergyNode> nodes = new List<EnergyNode>();
        List<EnergyGenator> generators = new List<EnergyGenator>();
        float[] tpsar = new float[5];
        int tps = 0;
        float timer = 0f;

        public void Start()
        {
            name = "--NetworkControler";

            tpsar[4] = 20;
            tpsar[3] = 20;
            tpsar[2] = 20;
            tpsar[1] = 20;
            tpsar[0] = 20;
        }

        void Awake()
        {
            StartCoroutine("CheckForChanges");
        }
        void Update()
        {
            CallculedWaitTime = 1f / TicksPerSecond;
            CheckForChangesInterval = CallculedWaitTime;

            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                tpsar[4] = tpsar[3];
                tpsar[3] = tpsar[2];
                tpsar[2] = tpsar[1];
                tpsar[1] = tpsar[0];
                tpsar[0] = tps;
                tps = 0;
                timer = 0;
                EnergyGlobals.RealTPS = (tpsar[4] + tpsar[3] + tpsar[2] + tpsar[1] + tpsar[0]) / 5f;
            }
        }

        IEnumerator CheckForChanges()
        {
            UpdateGride();
            while (true)
            {
                if (EnergyGlobals.LastNetworkObjectCount != EnergyGlobals.CurrentNetworkObjects)
                    UpdateGride();
                foreach (EnergyNode node in nodes)
                {
                    node.GetInRangeNodes(nodes);
                    node.sendPower();
                }
                foreach (EnergyGenator gen in generators)
                {
                    gen.GetInRangeNodes(nodes);
                    gen.sendPower();
                }
                tps++;
                yield return new WaitForSeconds(CallculedWaitTime);
            }
        }

        void OnApplicationStop()
        {
            StopCoroutine("CheckForChanges");
        }

        static public EnergyNetWorkControler GetThis()
        {
            EnergyNetWorkControler output = null;
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                if (go.name == "--NetworkControler")
                {
                    output = go.GetComponent<EnergyNetWorkControler>();
                    return output;
                }
            }
            if (output != null)
                return output;
            else
            {
                GameObject controler = Instantiate(Resources.Load("EnergyNetControler"), Vector3.zero, Quaternion.identity) as GameObject;
                output = controler.GetComponent<EnergyNetWorkControler>();
                output.Start();
                return output;
            }
        }

        public void UpdateGride()
        {
            Debug.Log("Updated Grid");
            nodes = new List<EnergyNode>();
            generators = new List<EnergyGenator>();
            foreach (GameObject go in EnergyGlobals.NetWorkObjects)
            {
                if (go != null)
                {
                    if (go.tag == EnergyTags.EnergyNode)
                    {
                        EnergyNode tmp = go.GetComponent<EnergyNode>();
                        nodes.Add(tmp);
                    }
                    else if (go.tag == EnergyTags.EnergyGenartor)
                    {
                        EnergyGenator tmp = go.GetComponent<EnergyGenator>();
                        generators.Add(tmp);
                    }
                }
            }
            EnergyGlobals.LastNetworkObjectCount = EnergyGlobals.CurrentNetworkObjects;
        }
    }
}
