using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

    public string label;
    public int loadLevel;
    public float posX;
    public float posY;


    void OnGUI()
    {
        if (GUI.Button(new Rect(posX, posY, 200, 40), label))
            Application.LoadLevel(loadLevel);
    }
}
