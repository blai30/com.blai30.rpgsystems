using System;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Rarity Tier")]
    public class RarityTier : ScriptableObject, ISerializationCallbackReceiver, IIdentifiable
    {
        #region Fields

        [SerializeField]
        protected string id = "";
        [SerializeField]
        private string rarityName = "New Rarity Tier Name";
        [SerializeField]
        private int rank = 0;
        [SerializeField]
        private Color color = new Color();

        #endregion

        public string Id => id;
        public string RarityName => rarityName;
        public int Rank => rank;
        public Color Color => color;

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
