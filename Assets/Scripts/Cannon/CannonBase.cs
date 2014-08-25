using UnityEngine;
using System.Collections;
namespace Cannon
{
    public class CannonBase : MonoBehaviour
    {

        public Vector2 power;
        [SerializeField]
        Material bMat;
        [SerializeField]
        Mesh bMes;

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(new Vector2(-power.x,power.y));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject b = new GameObject("Bullet");
                b.AddComponent<MeshRenderer>().material=bMat;
                b.AddComponent<MeshFilter>().mesh = bMes;
                b.AddComponent<Rigidbody>();
                b.AddComponent<SphereCollider>();
                b.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
                b.rigidbody.AddForce(power);

            }
        }
        void OnGUI()
        {
            float py = GUI.VerticalSlider(new Rect(20, 20, 20, 100), power.y, 1000, 0);
            float px = GUI.HorizontalSlider(new Rect(40, 20, 100, 20), power.x, 0, 1000);
            power = new Vector2(px, py);
        }
    }
}