using System.Collections.Generic;
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
        [SerializeField] private ItemRarity rarityTier = null;
        [SerializeField] private List<ItemCategory> itemCategories = null;

        public string ItemName => itemName;
        public Sprite ItemIcon => itemIcon;
        public bool CanSell => canSell;
        public int SellPrice => sellPrice;
        public ItemRarity RarityTier => rarityTier;
    }

    public abstract class StackableItem : Item
    {
        [SerializeField] private int maxStackQuantity = 100;

        public int MaxStackQuantity => maxStackQuantity;
    }

    internal interface IUsable
    {
        bool UseItem();
    }
}
