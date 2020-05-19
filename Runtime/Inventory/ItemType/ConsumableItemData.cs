using System;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Consumable Item", order = 2)]
    public class ConsumableItemData : ItemData, IUsable
    {
        public bool UseItem()
        {
            return false;
        }
    }
}
