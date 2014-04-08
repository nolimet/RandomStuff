using UnityEngine;
using System.Collections;
namespace EnergyNet
{
    public class Options : MonoBehaviour
    {

        void OnGUI()
        {
            if (GUI.Button(new Rect(20, 20, 200, 40), "Use LightParticles : " + EnergyGlobals.useLightParticles))
                EnergyGlobals.useLightParticles = !EnergyGlobals.useLightParticles;
            GUI.TextArea(new Rect(20, 60, 200, 40), "Real TPS : " + EnergyGlobals.RealTPS);
        }
    }

    public class EnergyGlobals : MonoBehaviour
    {
        static public bool useLightParticles = true;
        static public float RealTPS = 0;

        public static void SendPackage(Transform sender,Transform target, int senderID, int targetID, int Energy, float Speed = 0.1f)
        {
            GameObject energyPacket;
            if (!useLightParticles)
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