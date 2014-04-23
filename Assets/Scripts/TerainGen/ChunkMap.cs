using UnityEngine;
using System.Collections;
namespace TerainGen
{
    public class ChunkMap : MonoBehaviour
    {
        public GameObject Chunkobj;
        public Transform player;
        public int chunksize = 16;
        public int render_distance = 6;

        // Use this for initialization
        void Start()
        {
            GenerateChunks();



        }

        void GenerateChunks()
        {
            Vector3[] chunks = new Vector3[render_distance * render_distance];
            bool[] chunksbool = new bool[render_distance * render_distance];

            int i = 0;

            for (int x = (render_distance / 2) * -1; x < render_distance / 2; x++)
            {
                for (int z = (render_distance / 2) * -1; z < render_distance / 2; z++)
                {
                    int px = Mathf.RoundToInt(player.transform.position.x / chunksize) * chunksize;
                    int pz = Mathf.RoundToInt(player.transform.position.z / chunksize) * chunksize;
                    px = px + (x * chunksize);
                    pz = pz + (z * chunksize);
                    chunks[i] = new Vector3(px, 0, pz);
                    chunksbool[i] = true;
                    i = i + 1;
                }
            }

            for (i = 0; i < render_distance * render_distance; i++)
            {
                foreach (Transform child in transform)
                {

                    if (child.transform.position == chunks[i])
                    {
                        chunksbool[i] = false;

                    }
                }

            }
            for (i = 0; i < render_distance * render_distance; i++)
            {
                if (chunksbool[i])
                {
                    CreateChunk(chunks[i]);
                }
            }



        }


        void CreateChunk(Vector3 pos)
        {
            GameObject chunk = Instantiate(Chunkobj, pos, Quaternion.identity) as GameObject;
            //chunk.GetComponent<Chunk>().placed(new Vector2(16, 16), new Vector2(pos.x / 10, pos.z / 10),Mathf.FloorToInt(pos.y));
            chunk.transform.parent = transform;

        }
        void DestroyChunks()
        {
            int px = Mathf.RoundToInt(player.position.x / 16) * 16;
            int pz = Mathf.RoundToInt(player.position.z / 16) * 16;
            int renderer = Mathf.RoundToInt(render_distance + (render_distance / 2));


            foreach (Transform child in transform)
            {
                Vector2 ch = new Vector2(child.transform.position.x, child.transform.position.z);
                Vector2 pl = new Vector2(player.transform.position.x, player.transform.position.z);


                float dist = Vector2.Distance(ch, pl);

                if (dist > renderer * 20)
                {
                    Destroy(child.gameObject);

                }

            }


        }

        // Update is called once per frame
        void Update()
        {

            //GenerateChunks();
            DestroyChunks();
        }

    }
}