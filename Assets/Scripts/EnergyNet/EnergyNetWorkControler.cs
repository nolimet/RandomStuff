﻿using UnityEngine;
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

        #region Start and Updates
        public void Start()
        {
            if (!EnergyGlobals.createdPackageParent)
            {
                EnergyGlobals.createdPackageParent = true;
                GameObject ep = new GameObject();
                ep.name = "--EnergyPackages";
                EnergyGlobals.packageParent = ep.transform;
            }

            name = "--NetworkControler";
            StartCoroutine("CheckForChanges");
            StartCoroutine("RangeCheck");

            tpsar[4] = 20;
            tpsar[3] = 20;
            tpsar[2] = 20;
            tpsar[1] = 20;
            tpsar[0] = 20;
        }

        public void Stop()
        {
            StopCoroutine("CheckForChanges");
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
        #endregion

        #region IEnumerators
        IEnumerator CheckForChanges()
        {
            UpdateGride();
            Debug.Log(name + "Started Checker");
            while (Application.isPlaying)
            {
                if (EnergyGlobals.LastNetworkObjectCount != EnergyGlobals.CurrentNetworkObjects)
                    UpdateGride();
                foreach (EnergyNode node in nodes)
                {
                    node.sendPower();
                    node.GetPull();
                }

                foreach (EnergyGenator gen in generators)
                {
                    gen.Genarate();
                    gen.sendPower();
                }
                tps++;
                yield return new WaitForSeconds(CallculedWaitTime);
            }
        }

        IEnumerator RangeCheck()
        {
            Debug.Log(name + "Started RangeCheck");
            while (Application.isPlaying)
            {
                if (EnergyGlobals.LastNetworkObjectCount != EnergyGlobals.CurrentNetworkObjects)
                    UpdateGride();
                foreach (EnergyNode node in nodes)
                {
                    node.GetInRangeNodes(nodes);
                }

                foreach (EnergyGenator gen in generators)
                {
                    gen.GetInRangeNodes(nodes);
                }
                yield return new WaitForSeconds(CallculedWaitTime * 2f);
            }
        }
        #endregion

        #region misc functions
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
        #endregion

        #region enum Functions
        public void UpdateGride()
        {
            //Debug.Log(this.name + ": Updated Grid");
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
        #endregion
    }
}
