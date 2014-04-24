using UnityEngine;
using System.Collections;
namespace TerainGen
{
    public class _BlockBase : MonoBehaviour
    {
        public static void place(string type,Vector2 posinChunk,Vector2 chunk, Transform parent,float height=0f)
        {
            Vector3 pos = new Vector3 (posinChunk.x+chunk.x+0.5f,height,posinChunk.y+chunk.y+0.5f);
            GameObject newBlock = Instantiate(Resources.Load(type),pos , Quaternion.identity) as GameObject;
            newBlock.name = type +' '+ posinChunk + ' ' + chunk;
            newBlock.transform.parent = parent;
            newBlock.transform.localScale = new Vector3(1.001f, 1.001f, 1.001f);

            TerainGlobals.TotalBlocks++;
        }
    }
}