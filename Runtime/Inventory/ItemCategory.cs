using System;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Item Category", order = 0)]
    public class ItemCategory : ScriptableObject
    {
        [SerializeField]
        private string categoryName = "New Category";
        [SerializeField]
        private Sprite categoryIcon = null;
    }
}
