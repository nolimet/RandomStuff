using UnityEngine;
using System.Collections;
namespace EnergyNet
{
    public class EnergyGenator : EnergyBase
    {

        public override void Start()
        {
            base.Start();
            MaxStorage = 200;
        }

        void Send()
        {

        }
    
    }
}