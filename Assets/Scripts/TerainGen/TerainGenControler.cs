using UnityEngine;
using System.Collections;
namespace TerainGen
{
    public class TerainGenControler : MonoBehaviour
    {
        public bool generate = false;
        bool started = false;
        public Vector2 chunksize;
        public Vector2 fieldSize;

        void Update()
        {
            if (generate && !started)
            {
                StartCoroutine("TerainGen");
                started = true;
            }
        }

        IEnumerator TerainGen()
        {
            if(chunksize.x>0&&chunksize.y>0&&fieldSize.x>0&&fieldSize.y>0)
                for (int i = 0; i < fieldSize.x; i++)
                {
                    for(int j = 0; j<fieldSize.y; j++)
                    {
                        /*for (int k = 0; k < chunksize.x; k++)
                        {
                            for (int l = 0; l < chunksize.y; l++)
                            {
                              _BlockBase.place("Cube", new Vector2(k, l), new Vector2(i*chunksize.x+0.5f, j*chunksize.y+0.5f), 0f);
                                Debug.Log(l + " " + k + " " + j + " " + i);
                                yield return new WaitForSeconds(0.000001f);
                            }
                            //yield return new WaitForSeconds(0.0001f);
                        }*/
                        GameObject newChunk = Instantiate(Resources.Load("Chunk"), Vector3.zero, Quaternion.identity) as GameObject;
                        newChunk.GetComponent<Chunk>().placed(chunksize, new Vector2(i, j), 0);
                        yield return new WaitForSeconds(0.2f);
                    }
                }
            generate = false;
            started = false;
            StopCoroutine("TerainGen");
        }
    }
}