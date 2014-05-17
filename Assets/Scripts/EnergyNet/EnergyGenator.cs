using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnergyNet
{
    public class EnergyGenator : EnergyBase
    {

        private List<int> RevievedID = new List<int>();
        public int generation = 3;
        public bool activated = true;
        public int transferRate = 5;
        private int waitedTicks;
        private int controlerTPS = EnergyGlobals.MaxTPS;

        protected override void Start()
        {
            base.Start();
            //controler.AddNewGenerator(this);
            MaxStorage = 200;
            name = "Energy Genarator: " + ID;

        }

        public override void GetInRangeNodes(List<EnergyNode>_nodes)
        {
            base.GetInRangeNodes(_nodes);
            if (activated&&Storage < MaxStorage)
            {
                if(Storage-generation<=MaxStorage){
                Storage+=generation;
                }
                else
                {
                    Storage = MaxStorage;
                }
                if (Storage > MaxStorage)
                {
                    Storage = MaxStorage;
                }
            }
            //RevievedID = new List<int>();

        }

        public void sendPower()
        {
            waitedTicks++;
            if (waitedTicks >= controlerTPS)
            {
                waitedTicks = 0;
                if (activated && Storage > 0 && transferRate > 0)
                {
                    //check receiver's storage
                    int l = nodes.Count;
                    int k = RevievedID.Count;
                    for (int i = 0; i < l; i++)
                    {
                        bool receivedFrom = false;
                        for (int j = 0; j < k; j++)
                        {
                            if (RevievedID[j] == nodes[i].ID)
                            {
                                receivedFrom = true;
                            }
                        }
                        if (!receivedFrom)
                        {
                            if (Storage >= transferRate)
                            {
                                EnergyGlobals.SendPackage(transform, nodes[i].transform, ID, nodes[i].ID, transferRate);
                                Storage -= transferRate;
                            }
                        }
                    }
                }
            }
        }
    }
}