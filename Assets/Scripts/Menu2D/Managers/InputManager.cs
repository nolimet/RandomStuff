using UnityEngine;
using System.Collections;

namespace manager
{
    public class InputManager : MonoBehaviour
    {
        public bool esc = false;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                esc = true;
            else
                esc = false;

        }
    }
}
