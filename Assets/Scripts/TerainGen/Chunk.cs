using UnityEngine;
using System.Collections;
namespace TerainGen
{
    public class Chunk : MonoBehaviour
    {
        private Vector2 thisChunk;
        private Vector2 chunksize;
        private int height;
        // Use this for initialization             
        public void placed(Vector2 _chunkSize, Vector2 _chunk,int _height)
        {
            thisChunk=_chunk;
            chunksize=_chunkSize;
            height = _height;
            this.name = "Chunk " + _chunk;
            StartCoroutine("TerainGen");
        }

        private IEnumerator TerainGen()
        {
            Vector2 pos = new Vector2(thisChunk.x * chunksize.x, thisChunk.y * chunksize.y);
            if (height <= 0)
            {
                for (int k = 0; k < chunksize.x; k++)
                {
                    for (int l = 0; l < chunksize.y; l++)
                    {
                        int h = Mathf.FloorToInt(Mathf.PerlinNoise(pos.x + k, pos.y + l) * 32);
                        //Debug.Log(Mathf.PerlinNoise(pos.x + k, pos.y + l) * 32);
                        Debug.Log((pos.y + l) + " " + (pos.x + k));
                        _BlockBase.place("Cube", new Vector2(k, l), pos, transform, h);//a  test set last arg to 0f if fails
                        yield return new WaitForSeconds(0.000001f);
                    }
                }
            }
            else
            {
                for (int k = 0; k < chunksize.x; k++)
                {
                    for (int l = 0; l < chunksize.y; l++)
                    {
                        for (int h = 0; h < height; h++)
                        {
                            _BlockBase.place("Cube", new Vector2(k, l), pos, transform, h);
                            yield return new WaitForSeconds(0.000001f);
                        }
                    }
                }
            }
            StopCoroutine("TerainGen");
        }

    }
}