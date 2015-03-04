﻿using UnityEngine;
using System.Collections;


namespace menu_old
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TriggerV2 : MonoBehaviour
    {
        public int OpenMenuID;
        public bool Disabled;
        public bool State = false;
        public bool triggered = false;

        protected virtual void Start()
        {
            if (Disabled)
            {
                GetComponent<TextMesh>().GetComponent<Renderer>().material.color = Color.gray;
            }
        }

        protected virtual void IWillDo()
        {
            if (!Disabled)
            {
                State = true;
            }
        }
        protected virtual void OnMouseClick()
        {
            if (!Disabled)
            {
                State = true;
            }
        }
    }
}