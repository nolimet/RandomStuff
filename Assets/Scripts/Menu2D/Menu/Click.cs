using UnityEngine;
using System.Collections;

namespace menu
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Click : MonoBehaviour
    {
        public string LoadLevel;
        public bool ExitGame;
        public bool isButton;

        void Start()
        {
            if (LoadLevel == "" && !ExitGame)
            {
                Destroy(this);
            }
        }
        void IWillDo()
        {
            if (ExitGame && !Application.isWebPlayer && !Application.isEditor)
            {
                Application.Quit();
            }
            else if (LoadLevel != "")
            {
                transform.parent.parent.gameObject.GetComponent<Loader>().SyncLoadLevel(LoadLevel);

            }
        }
    }
}