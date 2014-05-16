using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EnergyNet
{
    public class EnergyNode : EnergyBase
    {
        public int transferRate = 2;
        public bool endPoint;
        private int waitedTicks;
        private int controlerTPS = EnergyGlobals.MaxTPS;


        private List<int> RevievedID = new List<int>();

        protected override void Start()
        {
            base.Start();
            SetNameID();
        }

        public virtual void receive(float receiving,int senderID)
        {
			if (Storage < MaxStorage) {Storage += receiving;}
            RevievedID.Add(senderID);
            if (Storage > MaxStorage) { Storage = MaxStorage; }
        }

        public virtual void sendPower()
        {
            if (ID == 0)
            {
                SetNameID();
            }
            waitedTicks++;
            if (waitedTicks >= controlerTPS)
            {
               // Debug.Log("sendpower : " + ID);
                waitedTicks = 0;
                if (!endPoint && Storage > 0 && transferRate > 0)
                {
                    int l = nodes.Count;
                    int k = RevievedID.Count;
                    for (int i = 0; i < l; i++)
                    {
                        bool receivedFrom = false;
                        if (nodes[i].nonRecivend)
                            receivedFrom = true;

                        if (!receivedFrom)
                            for (int j = 0; j < k; j++)
                            {
                                if (RevievedID[j] == nodes[i].ID)
                                {
                                    receivedFrom = true;
                                }
                            }
                        if (!receivedFrom && Storage >= transferRate)
                        {
                            EnergyGlobals.SendPackage(transform, nodes[i].transform, ID, nodes[i].ID, transferRate);
                            Storage -= transferRate;
                        }
                    }
                }
            }
        }
        public override void GetInRangeNodes(List<EnergyNode> _nodes)
        {
            base.GetInRangeNodes(_nodes);
        }

        protected override void Update()
        {
            if (!nonRecivend)
            {
                int l = nodes.Count;
                for (int i = 0; i < l; i++)
                {
                    if (nodes[i] != null && !nodes[i].nonRecivend && !RevievedID.Contains(nodes[i].ID))
                        Debug.DrawLine(transform.position, nodes[i].transform.position, Color.yellow);
                }
            }
            
        }

        protected override void SetNameID()
        {
            base.SetNameID();
            this.name = "Node " + ID;
        }
    }
}
