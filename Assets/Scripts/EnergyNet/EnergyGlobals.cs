using UnityEngine;
using System.Collections;
namespace EnergyNet
{
    public class EnergyGlobals :MonoBehaviour
    {
        static public bool useLightParticles = true;
        static public float RealTPS = 0;

        public static void SendPackage(Transform sender, Transform target, int senderID, int targetID, int Energy, float Speed = 0.1f, bool forceFancyParticle = false)
        {
            GameObject energyPacket;
            if (forceFancyParticle)
            {
                energyPacket = Instantiate(Resources.Load("EnergyPacket"), sender.position, Quaternion.identity) as GameObject;
            }
            else if (!useLightParticles)
            {
                energyPacket = Instantiate(Resources.Load("EnergyPacket"), sender.position, Quaternion.identity) as GameObject;
            }
            else
            {
                energyPacket = Instantiate(Resources.Load("EnergyPacket_Light"), sender.position, Quaternion.identity) as GameObject;
            }
            EnergyPacket packetScript = energyPacket.GetComponent<EnergyPacket>();
            packetScript.speed = Speed;
            packetScript.SentTo(target, Energy, senderID, targetID);
        }
    }
}
