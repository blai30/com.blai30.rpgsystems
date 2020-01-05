using UnityEngine;

namespace blai30.RPGSystems.InventorySystem
{
    public abstract class Item : ScriptableObject
    {
        public string itemName;
        public Sprite itemIcon;
    }
}
