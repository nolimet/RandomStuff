using UnityEngine;
using System.Collections;

namespace Audio
{
    public class AudioControler : MonoBehaviour
    {
        public AudioSource source;

        float volume= 100f;
        float pitch = 1f;
        bool circle = false;
        [SerializeField]
        AudioListener listen;
        [SerializeField]
        Texture2D textureBackdrop;

        Visualiser visu;
        VisualiserV2 visuv2;
        
        void Start()
        {
            visu = GetComponent<Visualiser>();
            if (!visu)
                visuv2 = GetComponent<VisualiserV2>();
        }

        void Update()
        {
            if (source != null)
            {
                UpdateSettings(source);
            }
            else
            {
                UpdateSettings(GetComponent<AudioSource>());
            }
        }

        void fOnGUI()
        {
            GUI.DrawTexture(new Rect(595, 25, 90, 110), textureBackdrop);
            volume = GUI.VerticalSlider(new Rect(600, 25, 30, 100), volume, 100f, 0f);
            pitch = GUI.VerticalSlider(new Rect(670, 25, 30, 100), pitch, 3, 0);
            if (GUI.Button(new Rect(650, 145, 80, 15), "Reset Pitch"))
                pitch = 1f;
            //if (GUI.Button(new Rect(640, 130, 100, 15), "Awesom Pitch"))
           //     pitch = 0.727272f;
            //if(GUI.Button(new Rect(150, 20, 100, 15), "Circle/Flat"))
            //    circle=!circle;
            GUI.TextField(new Rect (580,5,50,20),"Volume");
            GUI.TextField(new Rect(637f, 5, 75, 20), "Pitch:" + pitch);

            
        }

        void UpdateSettings(AudioSource editSource)
        {
            editSource.volume = volume/100f;
            editSource.pitch = pitch;
            if (listen == null)
                if (visu)
                    visu.circle = circle;
                else
                    visuv2.circle = circle;
            else
                listen.GetComponent<Visualiser>().circle = circle;
        }

        public void SetMode()
        {
            circle = !circle;
        }
    }
}