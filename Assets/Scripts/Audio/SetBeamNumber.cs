using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Audio
{
    public class SetBeamNumber : MonoBehaviour
    {
        #region Public var's
        public Rect dropDownRect = new Rect(125, 50, 125, 300);
        //public GUIStyle style;
        public string[] list = { "64", "128", "256", "512", "1024", "2048" };
        #endregion

        #region privateVars
        Vector2 scrollViewVector = Vector2.zero;
        Visualiser visu;

        bool play;
        bool show = false;

        int indexNumber;
        int UpdateSpeed;

        
        #endregion
        
        #region inEditorSetVars
        [SerializeField]
        GameObject UIControles;
        [SerializeField]
        Texture2D PlayButton;
        [SerializeField]
        Rect posPlay = new Rect();
        [SerializeField]
        Slider UpdateSpeedSlider;
        [SerializeField]
        Text UpdateSpeedText;
        [SerializeField]
        GameObject ConfigScreen;
        #endregion

        void Start()
        {
            #region Default Settings
            if (Application.isWebPlayer)
            {
                indexNumber = 2;
                UpdateSpeed = 0;
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                indexNumber = 1;
                UpdateSpeed = 0;
            }

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                indexNumber = 3;
                UpdateSpeed = 0;
            }
            else
            {
                indexNumber = 3;
                UpdateSpeed = 2;
            }
            #endregion

            visu = GetComponent<Visualiser>();
            posPlay = new Rect((Screen.width / 2) - 128, (Screen.height / 2) - 128, 256, 256);
            UIControles.SetActive(false);
            UpdateSpeedText.text = "Updates per second: " + ((UpdateSpeed * 5) + 30).ToString();
        }

        void Update()
        {
            visu.SpectrumLevel = indexNumber;
            visu.SpeedLevel = UpdateSpeed;
        }

        public void SetUpdateSpeed()
        {
            UpdateSpeed = Mathf.FloorToInt(UpdateSpeedSlider.value);
            UpdateSpeedText.text = "Updates per second: " + ((UpdateSpeed * 5) + 30).ToString();
            visu.AdjustUpdateSpeed(UpdateSpeed);
        }

        public void Play()
        {
            visu.play = true;
            enabled = false;
            UIControles.SetActive(true);
            ConfigScreen.SetActive(false);
        }

        void OnGUI()
        {
            //GUI.Label(new Rect(300, 25, 300, 75), "Having a low framerate?"+'\n' +"Lower the number of beams and/or update speed",visu.labelFix);
            //GUI.Label(new Rect((dropDownRect.x - 95), dropDownRect.y - 75, 150, 25), "UpdateSpeed: " + (30 + UpdateSpeed * 5), visu.labelFix);
            //UpdateSpeed = Mathf.FloorToInt(GUI.HorizontalSlider(new Rect((dropDownRect.x - 95), dropDownRect.y - 50, 120, 25), UpdateSpeed, 0, 18));
            #region Select Number of Beams
            if (GUI.Button(new Rect((dropDownRect.x - 100), dropDownRect.y, dropDownRect.width, 25), "" ))
            {
                if (!show)
                {
                    show = true;
                }
                else
                {
                    show = false;
                }
            }

            if (show)
            {
                scrollViewVector = GUI.BeginScrollView(new Rect((dropDownRect.x - 100), (dropDownRect.y + 25), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length * 25))));
                
                GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length * 25))), "");

                for (int index = 0; index < list.Length; index++)
                {

                    if (GUI.Button(new Rect(0, (index * 25), dropDownRect.height, 25), "" ))
                    {
                        show = false;
                        indexNumber = index;
                    }

                    GUI.Label(new Rect(5, (index * 25), dropDownRect.height, 25), list[index], visu.labelFix);

                }

                GUI.EndScrollView();
            }
            else
            {
                GUI.Label(new Rect((dropDownRect.x - 95), dropDownRect.y, 300, 25), list[indexNumber], visu.labelFix);
            }
            #endregion

            //if (GUI.Button(posPlay, PlayButton))
            //    play = true;

        }
    }
}