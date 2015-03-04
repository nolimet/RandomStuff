using UnityEngine;
using System.Collections;
namespace TerainGen
{
    public class Side : MonoBehaviour
    {
        public bool Active
        {
            set
            {
                Active = value;
                GetComponent<Renderer>().enabled = false;
                gameObject.SetActive(value);
            }
            get
            {
                return Active;
            }
        }

        public void Start()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, fwd,out hit, 0.5f)){
                Debug.Log("test");
                if (hit.transform.name == tag)
                {
                    hit.transform.gameObject.GetComponent<Side>().Active = false;
                    Active = false;
                    gameObject.SetActive(false);
                }
            } 
        }
    }
}