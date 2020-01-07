using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Consumable Item", order = 2)]
    public class ConsumableItem : StackableItem, IConsumable, IIngredient
    {
    }
}
