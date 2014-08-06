using UnityEngine;
using System.Collections;

public class LoadUI : MonoBehaviour
{

    void Start()
    {
        Application.LoadLevelAdditive("UI-Cam");
    }
}
