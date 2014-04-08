using UnityEngine;
using System.Collections;

namespace EnergyNet
{
    public class EnergyQuantumNode : EnergyNode
    {

        public bool IsSender = false;
        public EnergyQuantumNode TwinNode;

        protected override void Start()
        {
            base.Start();
            this.name = "QuantumNode " + ID;
            if (IsSender && TwinNode != null)
            {
                name += " Sender to " + TwinNode.ID;
                endPoint = true;
                nonRecivend = false;
                TwinNode.MaxStorage = MaxStorage;
            }
            else
            {
                name += "QuantumNode Reciever";
                endPoint = false;
                nonRecivend = true;
            }
        }

        public override void sendPower()
        {
            if (!IsSender)
            {
                base.sendPower();
                return;
            }
            if (Storage == MaxStorage)
            {
                EnergyGlobals.SendPackage(transform, TwinNode.transform, ID, TwinNode.ID, Mathf.FloorToInt( Storage),0.05f);
                Storage = 0;
                Debug.Log("BAM");
            }
        }

        public override void GetInRangeNodes(System.Collections.Generic.List<EnergyNode> _nodes)
        {
            base.GetInRangeNodes(_nodes);

        }
            
    }
}