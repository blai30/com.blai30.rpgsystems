using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    public abstract class Item : ScriptableObject
    {
        [Header("Properties")]
        [SerializeField] protected string itemName = "New Item";
        [SerializeField] protected Sprite itemIcon = null;
        [SerializeField] protected bool canSell = true;
        [SerializeField, Min(0)] protected int sellPrice = 10;
        [SerializeField] protected int maxStackQuantity = 100;
        [SerializeField] protected ItemRarity rarityTier = null;
        [SerializeField] protected List<ItemCategory> itemCategories = null;

        public string ItemName => itemName;
        public Sprite ItemIcon => itemIcon;
        public bool CanSell => canSell;
        public int SellPrice => sellPrice;
        public int MaxStackQuantity => maxStackQuantity;
        public ItemRarity RarityTier => rarityTier;

        private void OnValidate()
        {
            itemName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
        }
    }

    internal interface IUsable
    {
        bool UseItem();
    }
}
