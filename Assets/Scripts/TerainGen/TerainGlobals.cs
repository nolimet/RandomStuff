using UnityEngine;
using System.Collections;

public class TerainGlobals : MonoBehaviour {
    public static int TotalBlocks = 0;
    public static int buildingChunks = 0;

    public static void ResetGlobals()
    {
        TotalBlocks = 0;
        buildingChunks = 0;
    }
}
