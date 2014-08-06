using UnityEngine;
using System.Collections;
namespace menu
{
    public class OpenURL : MonoBehaviour
    {
        [SerializeField]
        private string url;

        void IWillDo()
        {
            if (url != null && url != "")
            {
                Application.OpenURL(url);
            }
        }
    }
}