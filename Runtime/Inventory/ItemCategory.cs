using System;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Item Category", order = 0)]
    public class ItemCategory : ScriptableObject
    {
        #region Fields

        [SerializeField]
        protected string id = "";
        [SerializeField]
        private string categoryName = "New Category";
        [SerializeField]
        private Sprite categoryIcon = null;

        #endregion

        public string Id => id;
        public string CategoryName => categoryName;
        public Sprite CategoryIcon => categoryIcon;

        public void OnBeforeSerialize()
        {
            // Generate new GUID if field is blank
            if (string.IsNullOrWhiteSpace(id))
            {
                id = Guid.NewGuid().ToString();
            }
        }

        public void OnAfterDeserialize()
        {
        }
    }
}
