using UnityEngine;
using System.Collections;
namespace EnergyNet
{
    public class f3dHitRay : MonoBehaviour
    {

        private string printName = "[3DHitRay] ";
        void Update()
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow,20f);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100) && hit.collider.tag == EnergyTags.EnergyNode)
                {
                    Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);
                    print(printName);
                    print(printName+hit.point+'\n'+printName+hit.collider.name);
                    EnergyNode node = hit.collider.gameObject.GetComponent<EnergyNode>();
                }
                //Debug.Log(
            }
        }

        void log(Object mess)
        {
            print(printName+mess);
        }
    }
}
