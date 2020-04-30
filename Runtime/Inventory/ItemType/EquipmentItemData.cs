using System;
using System.Collections;
using System.Collections.Generic;
using blai30.RPGSystems.Stats;
using Sirenix.OdinInspector;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Equipment Item", order = 0)]
    public class EquipmentItemData : ItemData, IUsable
    {
        [Serializable]
        public class StatBonus
        {
            [SerializeField] private StatType statType = null;
            [SerializeField] private StatModifierType modifierType = 0;
            [SerializeField] private float value = 0f;

            public StatType StatType => statType;
            public StatModifierType ModifierType => modifierType;
            public float Value => value;
        }

        protected const string GROUP_EQUIPMENT = "Equipment";

        #region Fields

        [SerializeField]
        [BoxGroup(GROUP_EQUIPMENT)]
        [ValueDropdown("GetEquipmentTypes", FlattenTreeView = true, NumberOfItemsBeforeEnablingSearch = 1)]
        protected EquipmentType equipmentType = null;

        [SerializeField]
        [BoxGroup(GROUP_EQUIPMENT)]
        [TableList]
        protected List<StatBonus> statBonuses = new List<StatBonus>();

        #endregion

        public EquipmentType EquipmentType => equipmentType;
        public List<StatBonus> StatBonuses => statBonuses;

        public EquipmentItemData()
        {
            maxStackQuantity = 1;
        }

        public bool UseItem()
        {
            return false;
        }

        private IEnumerable GetEquipmentTypes()
        {
            return RpgDatabase.GetAllScriptableObjects(typeof(EquipmentType));
        }
    }
}
