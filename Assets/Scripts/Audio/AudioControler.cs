using UnityEngine;
using System.Collections;

namespace Audio
{
    public class AudioControler : MonoBehaviour
    {
        public AudioSource source;

        float volume= 100f;
        float pitch = 1f;

        void Update()
        {
            if (source != null)
            {
                UpdateSettings(source);
            }
            else
            {
                UpdateSettings(audio);
            }
        }

        void OnGUI()
        {
            volume = GUI.VerticalSlider(new Rect(600, 25, 30, 100), volume, 100f, 0f);
            pitch = GUI.VerticalSlider(new Rect(670, 25, 30, 100), pitch, 3, 0);
            if (GUI.Button(new Rect(650, 145, 80, 15), "Reset Pitch"))
                pitch = 1f;
            if (GUI.Button(new Rect(640, 130, 100, 15), "Awesom Pitch"))
                pitch = 0.727272f;
            GUI.TextArea(new Rect (580,5,50,20),"Volume");
            GUI.TextArea(new Rect(650, 5, 50, 20), "Pitch");
        }

        void UpdateSettings(AudioSource editSource)
        {
            editSource.volume = volume/100f;
            editSource.pitch = pitch;
        }
    }
}