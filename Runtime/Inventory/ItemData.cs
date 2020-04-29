using System;
using System.Collections.Generic;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    public abstract class ItemData : ScriptableObject
    {
        [Header("Properties")]
        [SerializeField] protected string itemName = "New Item";
        [SerializeField] protected Sprite itemIcon = null;
        [SerializeField] protected bool canSell = true;
        [SerializeField, Min(0)] protected int sellPrice = 10;
        [SerializeField, Range(1, 999)] protected int maxStackQuantity = 100;
        [SerializeField] protected ItemRarity rarityTier = null;
        [SerializeField] protected List<ItemCategory> itemCategories = null;

        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }
        public Sprite ItemIcon => itemIcon;
        public bool CanSell => canSell;
        public int SellPrice => sellPrice;
        public int MaxStackQuantity => maxStackQuantity;
        public ItemRarity RarityTier => rarityTier;
    }

    internal interface IUsable
    {
        bool UseItem();
    }
}
