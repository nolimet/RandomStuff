using UnityEngine;
using System.Collections;
namespace Invetory.V2
{
    public class Item : MonoBehaviour
    {
        public ItemType type;
        [SerializeField]
        private WeaponType _weapon;
        public WeaponType weapon
        {
            get
            {
                if (type == ItemType.Weapon)
                    return _weapon;
                else
                    return WeaponType.none;
            }
            set
            {
                this._weapon = value;
            }
        }
        public Sprite icon;

        void Start()
        {
            GetComponent<UnityEngine.UI.Image>().sprite = icon;
            string tmp = name;
            name = type.ToString() + " ";

            if (weapon != WeaponType.none)
                name += weapon.ToString() + " ";
            name += tmp;
        }
    }

    public enum ItemType
    {
        Armor,
        Weapon,
        Misc,
        Key,
        Potion
    }

    public enum WeaponType
    {
        none,
        Sword,
        Bow,
        Shield
    }
}