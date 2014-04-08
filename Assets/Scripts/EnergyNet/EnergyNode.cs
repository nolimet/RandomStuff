using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EnergyNet
{
    public class EnergyNode : EnergyBase
    {
        public int transferRate = 2;
        public bool endPoint;
        private List<int> RevievedID = new List<int>();

        public override void Start()
        {
            base.Start();
            this.name = "Node " + ID;
        }

        public void receive(float receiving,int senderID)
        {
			//Debug.Log("Receiving: "+receiving);
           // Storage += receiving;
			if (Storage < MaxStorage) {Storage += receiving;}
            RevievedID.Add(senderID);
            if (Storage > MaxStorage) { Storage = 0; }
            //Debug.Log("Storage: " + Storage + " Max Storage: " + MaxStorage);
        }

        public void sendPower()
        {
            if (!endPoint)
            {
                if (Storage > 0 && transferRate > 0)
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
                                //Debug.Log(receivedFrom);
                            }
                        }
                        if (!receivedFrom)
                        {
                            if (Storage >= transferRate)
                            {
                                // Debug.Log("sending");
                                GameObject energyPacket;
                                if (!EnergyGlobals.useLightParticles)
                                {
                                   energyPacket = Instantiate(Resources.Load("EnergyPacket"), transform.position, Quaternion.identity) as GameObject;
                                }
                                else
                                {
                                    energyPacket = Instantiate(Resources.Load("EnergyPacket_Light"), transform.position, Quaternion.identity) as GameObject;
                                }
                                EnergyPacket packetScript = energyPacket.GetComponent<EnergyPacket>();
                                packetScript.SentTo(nodes[i].transform, transferRate, ID, nodes[i].ID);
                                Storage -= transferRate;
                            }
                        }
                    }
                }
            }
        }
        public override void GetInRangeNodes(List<EnergyNode> _nodes)
        {
            base.GetInRangeNodes(_nodes);
            //RevievedID = new List<int>();
            
        }
    }
}
