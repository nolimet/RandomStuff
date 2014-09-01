using UnityEngine;
using System.Collections;
namespace InvFrameWork
{
    [System.Serializable]
    public class GenericItem
    {
        public string Name = "nullItem";
        public int StackSize = 1;
        public string ImagePath;
        public Texture2D texture;


        /*
         * Run itemInit To create a new item.
         * It will set the name maxStacksize and imagePath 
         * 
         * 
         */
        virtual public void init()
        {

        }

        protected void itemInit(string _Name,int _StackSize ,string _ImagePath="")
        {
            Name = _Name;
            StackSize = _StackSize;
            if (_ImagePath == "")
                ImagePath = InventoryStatics.ResourceStartPath + Name;
            else
                ImagePath = InventoryStatics.ResourceStartPath + ImagePath;

            texture = Resources.Load(ImagePath, typeof(Texture2D)) as Texture2D;
        }
    }
}