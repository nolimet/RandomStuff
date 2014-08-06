using UnityEngine;
using System.Collections;

public class HitRayFirere : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        RaycastHit2D hit = new RaycastHit2D();
        Touch touch;
        if (Application.platform == RuntimePlatform.Android)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                {
                    touch = Input.GetTouch(i);
                    hit = Physics2D.Raycast(cam.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null)
                    {
                        hit.transform.gameObject.SendMessage("IWillDo", SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    hit.transform.gameObject.SendMessage("IWillDo", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}