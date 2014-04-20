using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool useGodRays;
    public int antiAliasLevel;
    

	// Use this for initialization
	void Start () {
        name = "GameManager";
        Object.DontDestroyOnLoad(this.gameObject);
        LoadData();
        ApplySettings();
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)&&Application.loadedLevel != 0)
        {
            Application.LoadLevel(0);
        }
	}

    public void ApplySettings()
    {
        Debug.Log("Applied Settings");
        SaveData();
        if (antiAliasLevel == 0)
            QualitySettings.antiAliasing = 0;
        if (antiAliasLevel == 1)
            QualitySettings.antiAliasing = 2;
        if (antiAliasLevel == 2)
            QualitySettings.antiAliasing = 4;
        if (antiAliasLevel == 3)
            QualitySettings.antiAliasing = 8;
    }

    void SaveData()
    {
        Debug.Log("Saved");
        PlayerPrefs.SetInt("antiAliasLevel", antiAliasLevel);

        PlayerPrefs.Save();
    }

    void LoadData()
    {
        if (PlayerPrefs.HasKey("antiAliasLevel"))
            antiAliasLevel = PlayerPrefs.GetInt("antiAliasLevel");
        else
            antiAliasLevel = PlayerPrefs.GetInt("antiAliasLevel");
    }

    static public GameManager find()
    {
        GameManager man = new GameManager();
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            if (go.name == "GameManager")
            {
                man = go.GetComponent<GameManager>();
                
            }
        }
        return (man);
    }
}
