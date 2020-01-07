using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Consumable Item", order = 1)]
    public class ConsumableItem : StackableItem, IConsumable
    {
    }
}
