using UnityEngine;
using System.Collections;
namespace TerainGen
{
    public class Chunk : MonoBehaviour
    {
        private Vector2 thisChunk;
        private Vector2 chunksize;
        private int Scale;
        private int Passes;
        private int Height;
        private float NoiseScale;
          
        public void placed(Vector2 _chunkSize, Vector2 _chunk,int _Scale,int _Passes,int _Height, float _NoiseScale)
        {
            thisChunk=_chunk;
            chunksize=_chunkSize;
            Scale = _Scale;
            Passes = _Passes;
            Height = _Height;
            NoiseScale = _NoiseScale;
            this.name = "Chunk: " + _chunk;
            StartCoroutine("TerainGen");
            transform.localScale = new Vector3(1, 1, 1);
        }

        private IEnumerator TerainGen()
        {
            TerainGlobals.buildingChunks++;
            Vector2 pos = new Vector2(thisChunk.x * chunksize.x, thisChunk.y * chunksize.y);
                for (int p = 0; p < Passes; p++)
                {
                    for (int k = 0; k < chunksize.x; k++)
                    {
                        for (int l = 0; l < chunksize.y; l++)
                        {

                            for (int h = 0; h < Height; h++)
                            {
                                int he = Mathf.FloorToInt(SimplexNoise.Noise.Generate((pos.x + k) * NoiseScale, (pos.y + l) * NoiseScale) * Scale);
                                    _BlockBase.place("Cube", new Vector2(k, l), pos, transform, he-h);//a  test set last arg to 0f if fails
                               /* if (h % 16 == 0)
                                {
                                    yield return new WaitForEndOfFrame();    
                                }*/
                            }
                        }
                        //yield return new WaitForEndOfFrame();  
                    }
                    yield return new WaitForEndOfFrame();  
                }
            Destroy(this, 0.2f);
            TerainGlobals.buildingChunks--;
            GetComponent<MeshMerger>().Merge();
            StopCoroutine("TerainGen");
        }

    }
}