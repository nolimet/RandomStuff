using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EnergyNet
{
    public class EnergyNode : EnergyBase
    {

        public int transferRate = 2;
        private List<EnergyNode> receivedLast = new List<EnergyNode>();

        public void receive(float receiving,EnergyNode sender)
        {
			Debug.Log("Receiving: "+receiving);
           // Storage += receiving;
			if (Storage < MaxStorage) {Storage += MaxStorage;}
            receivedLast.Add(sender);
            Debug.Log("Storage: " + Storage + " Max Storage: " + MaxStorage);
        }

        public void sendPower()
        {
			if (Storage > 0 && transferRate>0)
            {
                //check receiver's storage
                int l = nodes.Count;
                int k = receivedLast.Count;
                for (int i = 0; i < l; i++)
                {
                    bool receivedFrom = false;
                    for (int j = 0; j < k; j++)
                    {
                        if (receivedLast[j] == nodes[i])
                        {
                            receivedFrom = true;
                        }
                    }
                    if (!receivedFrom)
                    {
                        
                        if (Storage >= transferRate&&nodes[i].Storage+transferRate<=nodes[i].MaxStorage)
                        {
                            nodes[i].receive(transferRate, this.gameObject.GetComponent<EnergyNode>());
                            Storage -= transferRate;
                        }
                        else if (Storage>0&&nodes[i].Storage+transferRate <= nodes[i].MaxStorage)
                        {
                            nodes[i].receive(Storage, this.gameObject.GetComponent<EnergyNode>());
                            Storage = 0;
                        }
                        else 
                        {
                            //nodes[i].receive(
                        }
                    }
                }

                /*  if (nodes[i].Storage < MaxStorage)
                  {
                      if (Storage < transferRate)
                      {

                      }
                  }*/
            }
            else
            {
                Storage = 0;
            }
        }
        public override void GetInRangeNodes()
        {
            base.GetInRangeNodes();
            receivedLast = new List<EnergyNode>();
            
        }
    }
}
