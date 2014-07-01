using UnityEngine;
using System.Collections;

public class BeamControler : MonoBehaviour
{
    #region var's
    float level;
    float currentLevel;
    bool world;
    bool lastWorld;
    bool toLowLevel;
    #endregion

    #region Consts
    float barWidth;
    Vector3 pos;
    float lerpSpeed = 20f;
    Transform parent;
    #endregion

    public void setup(float @barWidth, Vector3 @pos)
    {
        this.barWidth = @barWidth;
        this.pos = @pos;
        transform.localScale = new Vector3(barWidth, 0.01f, 1f);
        transform.position = @pos;
        
        parent = transform.parent;
    }

    public void updateLocation(float @level, bool @world)
    {
        this.level = @level;
        this.world = @world;
        if (world)
            transform.parent = parent.parent;
        else
            transform.parent = parent;
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

	void Update () 
    {
        posUpdate();
        lerp();
	}

    void lerp()
    {
        //make it update faster when diffrece between current and desired is higher
        currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed);
    }

    void posUpdate()
    {
        if (!toLowLevel)
        {
            transform.localScale = new Vector3(barWidth, currentLevel, 1f);

            if (world)
                transform.position = new Vector3(0, currentLevel / 2f, pos.z);
            else
                transform.localPosition = new Vector3(0, currentLevel / 2f, 0);
        }
        if (!toLowLevel && currentLevel < 0.01f)
        {
            toLowLevel = true;
            level = 0;
        }

        else if (toLowLevel && currentLevel > 0.01f)
            toLowLevel = false;
    }
    public void DebugLog()
    {
        Debug.Log("LEVEL: "+level);
    }
}
