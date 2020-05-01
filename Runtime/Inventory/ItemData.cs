using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    public abstract class ItemData : ScriptableObject
    {
        protected const string GROUP_GENERAL = "General";
        protected const string GROUP_VALUE = "Value";
        protected const string GENERAL_VERTICAL_GROUP = "General/Split/Left";

        #region Fields

        [SerializeField]
        [BoxGroup(GROUP_GENERAL)]
        [VerticalGroup(GENERAL_VERTICAL_GROUP)]
        protected string itemName = "New Item";

        [SerializeField]
        [TextArea(4, 16)]
        [VerticalGroup(GENERAL_VERTICAL_GROUP)]
        protected string itemDescription = "";

        [SerializeField]
        [HideLabel, PreviewField(96)]
        [HorizontalGroup("General/Split", 96)]
        protected Sprite itemIcon = null;

        [SerializeField]
        [BoxGroup(GROUP_VALUE)]
        protected bool canSell = true;

        [SerializeField, Min(0), DisableIf(nameof(canSell), false)]
        [BoxGroup(GROUP_VALUE)]
        protected int sellPrice = 10;

        [SerializeField, Range(1, 999)]
        [BoxGroup(GROUP_VALUE)]
        protected int maxStackQuantity = 100;

        [SerializeField]
        [BoxGroup(GROUP_VALUE)]
        [AssetSelector(DropdownTitle = "Rarity tier")]
        protected RarityTier rarityTier = null;

        [SerializeField]
        [BoxGroup(GROUP_VALUE)]
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
