using UnityEngine;
using System.Collections;

namespace Menu
{
    public class Apply : MonoBehaviour
    {
        Button button;
        GameManager manager;
        void Start()
        {
            button=GetComponent<Button>();
            manager = GameManager.find();
        }

        void Update()
        {
            if (button.state)
            {
                manager.ApplySettings();
            }

        }
    }
}