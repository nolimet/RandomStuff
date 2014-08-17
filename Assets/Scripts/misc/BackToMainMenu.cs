using UnityEngine;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {

	void Start () {
        Object.DontDestroyOnLoad(this);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel(0);
    }
}
