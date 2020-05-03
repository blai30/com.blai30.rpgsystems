using System.Collections.Generic;
using blai30.RPGSystems.Stats;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Equipment Item", order = 0)]
    public class EquipmentItemData : ItemData, IUsable
    {
        #region Fields

        [SerializeField]
        protected EquipmentType equipmentType = null;

        [SerializeField]
        protected List<StatBonus> statBonuses = new List<StatBonus>();

        #endregion

        public EquipmentType EquipmentType => equipmentType;
        public List<StatBonus> StatBonuses => statBonuses;

        // public EquipmentItemData()
        // {
        //     maxStackQuantity = 1;
        // }

        public bool UseItem()
        {
            return false;
        }
    }
}
