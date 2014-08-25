using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Audio
{
    public class AudioStreamIn : MonoBehaviour
    {
        AudioClip currentSound;
        WWW currentStreamLocation;

        List<string> streamLocations = new List<string>();

        bool nextTrack = true;
        bool loadingNewClip;
        bool startedLoading;
        bool invaledUrl;
        int track;

        string trackCurrentTime;
        string trackDuration;

        Rect Center;
        void Start()
        {
            streamLocations.Add("https://dl.dropboxusercontent.com/u/101947295/audi/Ao_no_Exorcist_-_Core_Pride.mp3");
            Center = new Rect((Screen.width / 2f), (Screen.height / 2f),0,0);
        }
        void init(List<string> PlayList)
        {
            streamLocations = PlayList;
        }

        void Update()
        {
            if (!invaledUrl)
            {
                if (!audio.isPlaying && track < streamLocations.Count || nextTrack && track < streamLocations.Count)
                {
                    if (!startedLoading)
                    {
                        audio.Stop();
                        currentSound = getNewClip(new WWW(streamLocations[track]));
                        loadingNewClip = true;
                    }
                    if (!loadingNewClip)
                    {
                        audio.clip = currentSound;
                        audio.Play();
                        nextTrack = false;
                        startedLoading = true;
                        trackDuration = Soundlength(Mathf.FloorToInt(currentSound.length));
                        track++;
                        if (track >= streamLocations.Count)
                        {
                            track = 0;
                        }
                        Debug.Log("next");
                    }
                }
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
            if(loadingNewClip)
                GUI.Label(new Rect(Center.xMin,Center.yMin,40,120),"Loading new Clip");
            if (invaledUrl)
            {
                GUI.Label(new Rect(Center.xMin, Center.yMin, 40, 120), "Error occured while loading URL. URl is not valid or file type is not MP3");
                if (GUI.Button(new Rect(Center.xMin, Center.yMin + 40, 40, 120), "Restart"))
                    Application.LoadLevel(Application.loadedLevel);
            }
        }

        IEnumerator GetNewAudio()
        {
            try
            {
                AudioClip newClip = currentStreamLocation.GetAudioClip(false, false, AudioType.MPEG);
            }
            catch
            {
                invaledUrl = true;
            }

            while (!currentSound.isReadyToPlay)
            {
                yield return new WaitForEndOfFrame();
            }
            loadingNewClip = false;
        }

        AudioClip getNewClip(WWW clip){
            AudioClip newClip = clip.GetAudioClip(false, false, AudioType.MPEG);
            return newClip;
        }

        string Soundlength(int length)
        {
            int m = length / 60;
            int s = length % 60;
            string strs;
            if (s < 10)
                strs = "0" + s;
            else
                strs = "" + s;
            string str = " " + m + ":" + strs;
            return str;
        }
    }
}