using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Audio
{
    public class Visualiser : MonoBehaviour
    {
        [Range(0.01f, 100f)]
        public float audioDrawScale = 1f;
        [Range(64, 8192)]
        public int SpectrumSize;
        private int CSpecturSize;
        public List<BeamControler> cubes = new List<BeamControler>();

        public bool circle = true;
        bool cirlelastframe = false;
        bool play;
        bool playing;

        float heightCap = 12f;
        float barWidth;

        [SerializeField]
        [Range(30, 120)]
        int updatespeed;

        [SerializeField]
        Material beamMaterial;
        [SerializeField]
        Mesh beamMesh;
        [SerializeField]
        Texture2D PlayButton;

        [SerializeField]
        Rect posPlay = new Rect();
        // Use this for initialization
        void Start()
        {
            posPlay = new Rect((Screen.width / 2) - 128, (Screen.height / 2) - 128, 256, 256);
            if (Application.isWebPlayer)
            {
                SpectrumSize = 256;
                updatespeed = 30;
            }

            if(Application.platform==RuntimePlatform.Android)
            {
                SpectrumSize = 128;
                updatespeed = 30;
            }
            //PlaceBars();
            
        }
        #region Position Updates
        IEnumerator SoundUpdate()
        {
            while (Application.isPlaying)
            {
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

        void OnGUI()
        {
            if (GUI.Button(posPlay, PlayButton)) 
                play = true;
        }
        #region Place/Replace
        void ReplaceAllBars()
        {
            CSpecturSize = SpectrumSize;
            Debug.Log("ReplacedBeams");
            StopCoroutine("SoundUpdate");
            foreach (BeamControler g in cubes)
            {
                DestroyImmediate(g.transform.parent.gameObject);
            }
            PlaceBars();
        }

        void PlaceBars()
        {
            
            playing = true;

            barWidth = 25.6f / SpectrumSize;
            for (int i = 0; i < SpectrumSize; i++)
            {
                // GameObject cube = Instantiate(Resources.Load("SimpleCube"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                GameObject cube = new GameObject();
                cube.AddComponent<MeshFilter>().mesh = beamMesh;
                cube.AddComponent<MeshRenderer>().material = beamMaterial;
                cube.name = "bar" + i;

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
            CSpecturSize = SpectrumSize;

            GetComponent<PlayList>().enabled = true;
            GetComponent<AudioControler>().enabled = true;

            StartCoroutine("SoundUpdate");
        }
        #endregion

        
    }
}