using System;
using System.Collections.Generic;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    public abstract class ItemData : ScriptableObject
    {
        #region Fields

        [SerializeField]
        protected string itemName = "New Item";
        [SerializeField]
        protected string itemDescription = "";
        [SerializeField]
        protected Sprite itemIcon = null;
        [SerializeField]
        protected bool canSell = true;
        [SerializeField, Min(0)]
        protected int sellPrice = 10;
        [SerializeField, Range(1, 999)]
        protected int maxStackQuantity = 100;
        [SerializeField]
        protected RarityTier rarityTier = null;
        [SerializeField]
        protected List<ItemCategory> itemCategories = null;

        #endregion

        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }
        public string ItemDescription => itemDescription;
        public Sprite ItemIcon => itemIcon;
        public bool CanSell => canSell;
        public int SellPrice => sellPrice;
        public int MaxStackQuantity => maxStackQuantity;
        public RarityTier RarityTier => rarityTier;
        public List<ItemCategory> ItemCategories => itemCategories;
    }

    internal interface IUsable
    {
        bool UseItem();
    }
}
