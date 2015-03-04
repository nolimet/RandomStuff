using UnityEngine;
using System.Collections;
namespace TerainGen
{
    [RequireComponent(typeof(GUIText))]
    public class TerainGenControler : MonoBehaviour
    {
        public bool generate = false;
        bool started = false;

        //TerainGenStuff
        private Vector2 chunksize;
        [Range(2,32)]
        public int ChunkSize = 8;
        [Range(1,20)]
        public int MaxBuildingChunks = 3;
        [Range(0,1)]
        public float NoiseScale;
        public Vector2 fieldSize;
        public int Scale=5;
        public int Height;
        public int passes=2;
        private float Seed;

        private int neededblocks;
        //intervals
        [Range(0.01f,0.5f)]
        public float TestCanPlaceTime = 0.2f;
        [Range(0f, 0.5f)]
        public float ChunkPlaceVertTime = 0.2f;

       

        //public int[][] heightMap = new int[2][];

        void Start()
        {
           name = "--TerainControler";
           TerainGlobals.ResetGlobals();
           Seed = Random.Range(0, 1000000f) / 1000000f;
           neededblocks = Mathf.FloorToInt(ChunkSize*ChunkSize*Height*fieldSize.x*fieldSize.y*passes);
        }

        void Update()
        {
            chunksize = new Vector2(ChunkSize, ChunkSize);
            GetComponent<GUIText>().text = "TotalBlocks: " + TerainGlobals.TotalBlocks + " Of "+neededblocks+'\n' + "Seed: " + Seed;
            if (generate && !started)
            {
                StartCoroutine("TerainGen");
                started = true;
            }
        }

        void OnGUI()
        {
            if(!generate){
            if (GUI.Button(new Rect(50, 150, 200, 50), "StartBuilding"))
                generate = true;}
            else if (GUI.Button(new Rect(50, 150, 200, 50), "Building"))
                Debug.Log("steve");
            if (GUI.Button(new Rect(50, 350, 200, 50), "Reset"))
            {

                Instantiate(Resources.Load("--TerainControler"), transform.position, Quaternion.identity);
                StopAllCoroutines();
                Destroy(this.gameObject);
            }
        }

        IEnumerator TerainGen()
        {
            if (chunksize.x > 0 && chunksize.y > 0 && fieldSize.x > 0 && fieldSize.y > 0)
            {
              //  int h = 3;
                for (int i = 0; i < fieldSize.x; i++)
                {
                    for (int j = 0; j < fieldSize.y; j++)
                    {
                       // h = 3;
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
                       // if (i == 2 && j == 2)
                       //     h = 3;
                        //Debug.Log("test");
                        GameObject newChunk = Instantiate(Resources.Load("Chunk"), Vector3.zero, Quaternion.identity) as GameObject;
                        newChunk.transform.parent = transform;
                        newChunk.GetComponent<Chunk>().placed(chunksize, new Vector2(i, j), Scale, passes, Height, NoiseScale*Seed);
                        while (TerainGlobals.buildingChunks>=MaxBuildingChunks)
                        {
                            yield return new WaitForSeconds(TestCanPlaceTime);
                        }
                        
                    }
                    if(ChunkPlaceVertTime>0f)
                    yield return new WaitForSeconds(ChunkPlaceVertTime);
                }
            }
            generate = false;
            started = false;
            StopCoroutine("TerainGen");
        }
    }
}