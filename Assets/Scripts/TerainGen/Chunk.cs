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
        //private Color chunkcolour;
        // Use this for initialization             
        public void placed(Vector2 _chunkSize, Vector2 _chunk,int _Scale,int _Passes,int _Height, float _NoiseScale)
        {
            thisChunk=_chunk;
            chunksize=_chunkSize;
            Scale = _Scale;
            Passes = _Passes;
            Height = _Height;
            NoiseScale = _NoiseScale;
            this.name = "Chunk: " + _chunk;
            //float tmp = Random.value;
            //chunkcolour = new Color(tmp, tmp, tmp);
           // GetComponent<MeshMerger>().material.color = chunkcolour;
            StartCoroutine("TerainGen");
        }

        private IEnumerator TerainGen()
        {
            TerainGlobals.buildingChunks++;
            Vector2 pos = new Vector2(thisChunk.x * chunksize.x, thisChunk.y * chunksize.y);
           // if (Height <=256)
           // {
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
                                if (h % 16 == 0)
                                {
                                    yield return new WaitForSeconds(0.03f);
                                        
                                }
                            }
                        }
                        yield return new WaitForSeconds(0.001f);
                    }
                    yield return new WaitForSeconds(0.5f);
                }
            //}
            /*else if (Height > 2000)
            {
                int normalLoops = Mathf.FloorToInt(Height / 16);
                int leftOvers = Mathf.FloorToInt(Height % 16);
                for (int k = 0; k < chunksize.x; k++)
                {
                    for (int l = 0; l < chunksize.y; l++)
                    {
                        for (int n = 0; n < normalLoops; n++)
                        {
                            for (int h = 0; h < 16; h++)
                            {
                                int he = Mathf.FloorToInt(SimplexNoise.Noise.Generate(pos.x + k, pos.y + l, h*n) * Scale);

                                if (he > 0)
                                    _BlockBase.place("Cube", new Vector2(k, l), pos, transform , he);//a  test set last arg to 0f if fails
                                else
                                {
                                    _BlockBase.place("Cube", new Vector2(k, l), pos, transform , -he);
                                }
                            }
                            yield return new WaitForSeconds(0.001f);
                        }

                        for (int h = 0; h < leftOvers; h++)
                        {
                            int he = Mathf.FloorToInt(SimplexNoise.Noise.Generate(pos.x + k, pos.y + l, h+(Height-leftOvers)) * Scale);

                            if (he > 0)
                                _BlockBase.place("Cube", new Vector2(k, l), pos, transform , he);//a  test set last arg to 0f if fails
                            else
                            {
                                _BlockBase.place("Cube", new Vector2(k, l), pos, transform , -he);
                            }
                            yield return new WaitForSeconds(0.001f);
                        }
                    }
                }
            }*/
            Destroy(this, 0.2f);
            TerainGlobals.buildingChunks--;
            GetComponent<MeshMerger>().Merge();
            StopCoroutine("TerainGen");
        }

    }
}