using UnityEngine;
using System.Collections;
namespace EnergyNet
{
    public class Options : MonoBehaviour
    {

        void OnGUI()
        {
            if (GUI.Button(new Rect(20, 20, 200, 40), "Use LightParticles: " + EnergyGlobals.useLightParticles))
                EnergyGlobals.useLightParticles = !EnergyGlobals.useLightParticles;
        }
    }

    public class EnergyGlobals : MonoBehaviour
    {
        static public bool useLightParticles = false;
    }
}