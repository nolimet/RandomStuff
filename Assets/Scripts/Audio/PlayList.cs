using UnityEngine;
using System.Collections;
namespace Audio
{
    public class PlayList : MonoBehaviour
    {

        public AudioClip[] playList;
        int track;
        bool nextTrack = false;
        void Update()
        {
            if (!audio.isPlaying && track < playList.Length  || nextTrack && track < playList.Length)
            {
                
                audio.Stop();
                audio.clip = playList[track];
                audio.Play();
                nextTrack = false;
                track++;
                Debug.Log("next");
            }
            if (track >= playList.Length)
            {
                track = 0;
            }
        }
        void OnGUI()
        {
            if (GUI.Button(new Rect(20, 20, 100, 15), "Next Track"))
                nextTrack = true;
            GUI.TextArea(new Rect(20, 42, 500, 20), audio.clip.name);
        }
    }
}
