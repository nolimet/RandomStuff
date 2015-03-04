using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace Invetory.V2
{
    public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static GameObject selected;
        public Vector3 StartPos;
        public Transform StartParent;
        Vector2 mouseOffSet;

        public void OnBeginDrag(PointerEventData eventData)
        {
            mouseOffSet = eventData.position - (Vector2)transform.position;
            selected = gameObject;
            StartPos = transform.position;
            StartParent = transform.parent;
            transform.SetParent(Inventory.instance.itemMove);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position - mouseOffSet;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
           // transform.SetParent(StartParent);
            selected = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if(eventData.pointerEnter.tag=="item")
            {
                transform.SetParent(eventData.pointerEnter.transform.parent);
                eventData.pointerEnter.transform.SetParent(StartParent);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(eventData.pointerEnter.transform.parent.gameObject, null, (x, y) => x.onHasChanged());
            }
            if (transform.parent == StartParent || transform.parent==Inventory.instance.itemMove)
            {
                transform.SetParent(StartParent);
                transform.position = StartPos;
            }

        }
    }
}