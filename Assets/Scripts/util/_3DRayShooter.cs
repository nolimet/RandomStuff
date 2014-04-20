using UnityEngine;
using System.Collections;

public class _3DRayShooter : MonoBehaviour
{

    public int Range;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider != null)
            {
                hit.transform.gameObject.SendMessage("3dHitray", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
