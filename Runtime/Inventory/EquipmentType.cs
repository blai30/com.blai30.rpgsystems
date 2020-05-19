using System;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [Serializable]
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Equipment Type")]
    public class EquipmentType : ScriptableObject, ISerializationCallbackReceiver
    {
        #region Fields

        [SerializeField]
        protected string id = "";
        [SerializeField]
        protected new string name = "New Equipment Type Name";
        [SerializeField]
        protected Sprite icon = null;

        #endregion

        public string Id => id;
        public string Name => name;
        public Sprite Icon => icon;

        public void OnBeforeSerialize()
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }
        }

        public void OnAfterDeserialize()
        {
        }
    }
}
