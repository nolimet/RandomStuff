using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace Invetory.V2
{
    public class Inventory : MonoBehaviour, IHasChanged
    {
        [SerializeField]
        Transform slots;
        [SerializeField]
        UnityEngine.UI.Text InventoryText;
        // Use this for initialization
        void Start()
        {
            onHasChanged();
        }

        public void onHasChanged()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(" - ");
            foreach (Transform slot in slots)
            {
                GameObject item = slot.GetComponent<ItemSlot>().item;
                if(item){
                    builder.Append(item.name);
                    builder.Append(" - ");
                }
            }
            InventoryText.text = builder.ToString();
        }
    }
}
namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void onHasChanged();
    }
}
