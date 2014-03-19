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
            Storage += receiving;
            if (Storage > MaxStorage) Storage = MaxStorage;
            receivedLast.Add(sender);
        }

        public void sendPower()
        {

            //check receiver's storage
            int l = nodes.Count;
            for (int i = 0; i < l; i++)
            {
                
                if (nodes[i].Storage < MaxStorage)
                {
                    if (Storage < transferRate)
                    {
                       
                    }
                }
            }
        }
        public override void GetInRangeNodes()
        {
            base.GetInRangeNodes();
            receivedLast = new List<EnergyNode>();
            
        }
    }
}
