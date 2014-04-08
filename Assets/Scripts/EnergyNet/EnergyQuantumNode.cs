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
            this.name = "QuantumNode " + ID;
            if (IsSender && TwinNode != null)
            {
                name += " Sender to " + TwinNode.ID;
                endPoint = true;
                nonRecivend = false;
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
            base.sendPower();
        }
            
    }
}