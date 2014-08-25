﻿using UnityEngine;
using System.Collections;
namespace Audio
{
    public class PlayList : MonoBehaviour
    {

        public AudioClip[] playList;
        int track;
        bool nextTrack = false;
        int tracklength;
        string trackDuration;
        string trackCurrentTime;
        void Update()
        {
            if (!audio.isPlaying && track < playList.Length  || nextTrack && track < playList.Length)
            {
                
                audio.Stop();
                audio.clip = playList[track];
                audio.Play();
                nextTrack = false;
                trackDuration = Soundlength(Mathf.FloorToInt(playList[track].length));
                track++;
                if (track >= playList.Length)
                {
                    track = 0;
                }
                Debug.Log("next");
            }
            trackCurrentTime = Soundlength(Mathf.FloorToInt(audio.time));
            
        }
        void OnGUI()
        {
            if (audio.clip == null)
                return;
            if (GUI.Button(new Rect(20, 20, 100, 15), "Next Track"))
                nextTrack = true;
            GUI.Label(new Rect(20, 42, 500, 20), audio.clip.name);
            GUI.Label(new Rect(20, 72, 500, 20), trackCurrentTime + " / " + trackDuration);
        }

        string Soundlength(int length)
        {
            int m = length/60;
            int s = length%60;
            string strs;
            if (s < 10)
                strs = "0" + s;
            else
                strs = ""+s;
            string str = " " + m + ":" + strs;
            return str;
        }
    }
}
