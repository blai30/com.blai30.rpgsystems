using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    public abstract class Item : ScriptableObject
    {
        [Header("Properties")]
        [SerializeField] private string itemName = "New Item";
        [SerializeField] private Sprite itemIcon = null;
        [SerializeField] private bool canSell = true;
        [SerializeField, Min(0)] private int sellPrice = 10;

        public string ItemName => itemName;
        public Sprite ItemIcon => itemIcon;
        public bool CanSell => canSell;
        public int SellPrice => sellPrice;
    }

    public abstract class StackableItem : Item
    {
        [SerializeField] private int maxStackQuantity = 100;

        public int MaxStackQuantity => maxStackQuantity;
    }

    internal interface IEquippable
    {
    }

    internal interface IConsumable
    {
    }

    internal interface IIngredient
    {
    }
}
