using UnityEngine;
using System.Collections;
namespace Menu
{
    public class AntiAliase : MonoBehaviour
    {

        public Button left;
        public Button right;
        private int antiAliasLevel = 0;
        private TextMesh text;
        public GameManager manager;

        void Start()
        {
            manager = GameManager.find();
            text = GetComponent<TextMesh>();
            antiAliasLevel = manager.antiAliasLevel;
            updateText();
        }

        void Update()
        {
            if (right.state)
            {
                if (antiAliasLevel < 3)
                    antiAliasLevel++;
                updateText();
            }

            if (left.state)
            {
                if (antiAliasLevel > 0)
                    antiAliasLevel--;
                updateText();
            }
        }

        void updateText()
        {
            manager.antiAliasLevel = antiAliasLevel;
            if (antiAliasLevel == 0)
                text.text = "X" + 0;
            if (antiAliasLevel == 1)
                text.text = "X" + 2;
            if (antiAliasLevel == 2)
                text.text = "X" + 4;
            if (antiAliasLevel == 3)
                text.text = "X" + 8;
        }
    }
}