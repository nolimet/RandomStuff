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
    public class Visualiser : MonoBehaviour
    {
        //Variablen
        #region General var's
        [SerializeField]
        [Range(0.01f, 100f)]
        float audioDrawScale = 50f;

        [SerializeField]
        [Range(64, 8192)]
        int SpectrumSize;

        List<BeamControler> cubes = new List<BeamControler>();

        bool cirlelastframe = false;
        
        bool playing;

        float heightCap = 12f;
        float barWidth;

        [SerializeField]
        [Range(30, 120)]
        int updatespeed;
        #endregion
        #region InEditorSetVars
        [SerializeField]
        Material beamMaterial;
        [SerializeField]
        Mesh beamMesh;

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

        public static Visualiser instance;
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
                CodeProfiler.Begin("Audio:PositionUpdater");
                float[] spectrum = audio.GetSpectrumData(SpectrumSize, 0, FFTWindow.BlackmanHarris);
                //Quaternion temprot;
                int i = 0;
                float channelSize = 0f;
                while (i < SpectrumSize)
                {
                    channelSize = spectrum[i] * audioDrawScale;
                    //limiter
                        if (channelSize > heightCap)
                        {
                            channelSize = heightCap / audioDrawScale;
                        }
                        cubes[i].updateLocation(channelSize, !circle);
                    i++;
                }
                cirlelastframe = circle;
                CodeProfiler.End("Audio:PositionUpdater");
                yield return new WaitForSeconds(1f / updatespeed);
            }
            Debug.Log("stopped");
        }
        
        void UpdateRot(Transform pivot, Transform cube, int i)
        {
            pivot.transform.rotation = Quaternion.Euler((360f / SpectrumSize) * i, 0f, 0f);
            pivot.transform.localPosition = Vector3.zero;
            pivot.transform.Translate(0, 0, 1);
            pivot.transform.rotation = Quaternion.Euler((360f / SpectrumSize) * i + 90, 0f, 0f);
            heightCap = 5f;
        }
        #endregion
        #region Place/Replace
        void SetOptions()
        {
            SpectrumSize = Mathf.FloorToInt(Mathf.Pow(2, 6 + SpectrumLevel));
            updatespeed = 30 + 5 * SpeedLevel;
        }

        void PlaceBars()
        {
            SetOptions();
            playing = true;

            barWidth = 25.6f / SpectrumSize;
            for (int i = 0; i < SpectrumSize; i++)
            {
               //building a cube
                GameObject cube = new GameObject();
                cube.AddComponent<MeshFilter>().mesh = beamMesh;
                cube.AddComponent<MeshRenderer>().material = beamMaterial;
                cube.name = "bar" + i;
                
                //building a pivot point
                GameObject pivot = new GameObject();
                pivot.transform.parent = transform;
                cube.transform.parent = pivot.transform;
                cube.transform.rotation = Quaternion.Euler(0, 270, 0);
                pivot.name = "Pivot" + i;

                UpdateRot(pivot.transform, cube.transform, i);
                cube.AddComponent<BeamControler>().setup(barWidth, new Vector3(0, 0, barWidth * i));
                cubes.Add(cube.GetComponent<BeamControler>());
            }
            cirlelastframe = circle;

            GetComponent<PlayList>().enabled = true;
            GetComponent<AudioControler>().enabled = true;
            GetComponent<SetBeamNumber>().enabled = false;

            StartCoroutine("SoundUpdate");
        }
        #endregion

        
    }
}
