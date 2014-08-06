using UnityEngine;
using System.Collections;
namespace Audio
{
    public class PlayList : MonoBehaviour
    {

        public AudioClip[] playList;
        int track;
        bool nextTrack = false;
        int tracklength;
        void Update()
        {
            if (!audio.isPlaying && track < playList.Length  || nextTrack && track < playList.Length)
            {
                
                audio.Stop();
                audio.clip = playList[track];
                audio.Play();
                nextTrack = false;
                tracklength = Mathf.FloorToInt(playList[track].length);
                track++;
                if (track >= playList.Length)
                {
                    track = 0;
                }
                Debug.Log("next");
                
                
            }
            
        }
        void OnGUI()
        {
            if (GUI.Button(new Rect(20, 20, 100, 15), "Next Track"))
                nextTrack = true;
            GUI.Label(new Rect(20, 42, 500, 20), audio.clip.name);
            GUI.Label(new Rect(20,72,500,20), " " + Mathf.FloorToInt(audio.time) + " / " + tracklength);
        }
    }
}
