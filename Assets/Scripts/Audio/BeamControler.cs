﻿using UnityEngine;
using System.Collections;

[HideInInspector]
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

    void Start()
    {
        
    }

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
        //CodeProfiler.Begin("Beam:Transforming");
        //world refers to in world position if it's not using world it just update the local postion and scale;
        this.level = @level;
        this.world = @world;
        if (world != lastWorld)
        {
            transform.localScale = new Vector3(barWidth, currentLevel, 1f);
            if (world)
            {
                transform.position = new Vector3(0, currentLevel / 2f, pos.z);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                transform.localPosition = new Vector3(0, currentLevel / 2f, 0);
                transform.localRotation = Quaternion.Euler(0, -90, 0);
            }
            lastWorld = world;
        }
        //CodeProfiler.End("Beam:Transforming");
    }

	void Update () 
    {
        posUpdate();
        lerp();
	}

    void lerp()
    {
       // CodeProfiler.Begin("Beam:Lerp");
        float leveldiff = level - currentLevel;
        if (leveldiff > 0.4f && leveldiff < 1f)
            currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed * 3f);
        else if(leveldiff > 1f && leveldiff <2f)
            currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed * 1.4f);
        else if (leveldiff > 2f && leveldiff < 3f)
            currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed * 1.8f);
        else if(leveldiff >= 3f && leveldiff<4f)
            currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed * 2f);
        else if(leveldiff >=4f && leveldiff<5f)
            currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed * 3f);
        else if (leveldiff >= 5f)
            currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed * 5f);
        else
            currentLevel = Mathf.Lerp(currentLevel, level, Time.deltaTime * lerpSpeed);
       // CodeProfiler.End("Beam:Lerp");
    }

    void posUpdate()
    {
       // CodeProfiler.Begin("Beam:PosUpdate");
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
        //CodeProfiler.End("Beam:PosUpdate");
    }
}
