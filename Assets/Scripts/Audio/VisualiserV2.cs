using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SetBeamNumber))]
    [RequireComponent(typeof(AudioStreamIn))]
    [RequireComponent(typeof(AudioControler))]
    [RequireComponent(typeof(PlayList))]
    public class VisualiserV2 : MonoBehaviour
    {
        //Variablen
        #region General var's
        [SerializeField]
        [Range(0.01f, 100f)]
        float audioDrawScale = 50f;

        [SerializeField]
        [Range(64, 8192)]
        int SpectrumSize;

        bool cirlelastframe = false;
        
        bool playing;

        float heightCap = 12f;

        [SerializeField]
        [Range(30, 120)]
        int updatespeed;

        Texture2D visualTexture;

        [SerializeField]
        int barHeight = 256;
        [SerializeField]
        Color BarLowerColor, BarHeigherColor;
        #endregion
        #region InEditorSetVars

        [SerializeField]
        Renderer visual;
        #endregion
        #region public var's
        [HideInInspector]
        public bool play = false;
        [HideInInspector]
        public bool circle = true;
        [HideInInspector]
        public int SpectrumLevel;
        [HideInInspector]
        public int SpeedLevel;
        public GUIStyle labelFix;

        public static VisualiserV2 instance;
        #endregion

        //Functions
        #region StartUP
        void Update()
        {
            if (!playing)
            {
                if (play)
                {
                    PlaceBars();
                }
            }
            else
            {
                enabled = false;
            }
        }

        #endregion
        #region Position Updates
        IEnumerator SoundUpdate()
        {
            while (Application.isPlaying)
            {
                // CodeProfiler.Begin("Audio:PositionUpdater");
                float[] spectrum = new float[SpectrumSize];
                int[] calculated = new int[SpectrumSize];

                GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
                
                //Quaternion temprot;
                int i = 0;
                float channelSize = 0f;
                while (i < SpectrumSize)
                {
                    channelSize = spectrum[i] * barHeight;
                    //limiter
                        if (channelSize > barHeight)
                        {
                            channelSize = barHeight;
                        }

                    calculated[i] = Mathf.FloorToInt(channelSize);
                    i++;
                }

                //visualTexture = new Texture2D(SpectrumSize, barHeight, TextureFormat.ARGB32,false);
              

                float f = 1f / audioDrawScale;
                for (int x = 0; x < visualTexture.width; x++)
                {
                    for (int y = 0; y < visualTexture.height; y++)
                    {

                        if (calculated[x] >= y)
                        {
                            visualTexture.SetPixel(x, y, Color.Lerp(BarLowerColor, BarHeigherColor, f*y));
                        }
                        else
                        {
                            visualTexture.SetPixel(x, y, Color.black);
                        }
                        
                    }
                }
                visualTexture.Apply();
                visual.material.mainTexture = visualTexture;
                cirlelastframe = circle;
                //CodeProfiler.End("Audio:PositionUpdater");
                yield return new WaitForSeconds(1f / updatespeed);
            }
            Debug.Log("stopped");
        }
        
        void UpdateRot(Transform pivot, Transform cube, int i)
        {
            
        }
        #endregion
        #region Place/Replace
        void SetOptions()
        {
            SpectrumSize = Mathf.FloorToInt(Mathf.Pow(2, 6 + SpectrumLevel));
            updatespeed = 30 + 5 * SpeedLevel;
        }

        public void AdjustUpdateSpeed(int value)
        {
            updatespeed = 30 + 5 * value;
        }

        void PlaceBars()
        {
            SetOptions();
            playing = true;

            visualTexture = new Texture2D(SpectrumSize, barHeight, TextureFormat.ARGB32,false);
            visualTexture.filterMode = FilterMode.Point;
            visualTexture.anisoLevel = 0;

            ProceduralTexture t = new ProceduralTexture();
           // t.
            cirlelastframe = circle;

            GetComponent<PlayList>().enabled = true;
            GetComponent<AudioControler>().enabled = true;
            GetComponent<SetBeamNumber>().enabled = false;

            visual.material.mainTexture = visualTexture;

            StartCoroutine("SoundUpdate");
        }
        #endregion

        
    }
}
