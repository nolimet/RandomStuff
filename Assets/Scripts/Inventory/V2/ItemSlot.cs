using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
namespace Invetory.V2
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        public GameObject item
        {
            get
            {
                if (transform.childCount > 0)
                    return transform.GetChild(0).gameObject;
                else
                    return null;
            }

        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                ItemDrag.selected.transform.SetParent(transform);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null,(x,y) => x.onHasChanged());
            }
        }
    }
}