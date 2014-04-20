using UnityEngine;
using System.Collections;

namespace Menu
{
    public class Button : MonoBehaviour
    {

        public bool _state;
        public int linkingToMenu;
        void OnMouseDown()
        {
            _state = true;
        }

        public bool state
        {
            get { if (_state) { _state = false; return true; } else { return false; } }
        }
    }
}
