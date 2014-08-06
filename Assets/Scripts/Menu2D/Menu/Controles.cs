using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(this);
	}

    public bool GamePaused;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.loadedLevel == 1)
            {
                Application.LoadLevel(0);
                Destroy(this.gameObject);
            }
            else
            {
                GamePaused = !GamePaused;
            }
        }
	}
}
