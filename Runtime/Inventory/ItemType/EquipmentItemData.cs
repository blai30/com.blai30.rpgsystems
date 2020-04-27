using System;
using System.Collections.Generic;
using blai30.RPGSystems.Stats;
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

        [Header("Equipment Item")]
        [SerializeField] protected EquipmentType equipmentType = null;
        [SerializeField] protected List<StatBonus> statBonuses = new List<StatBonus>();

        public List<StatBonus> StatBonuses => statBonuses;

        public EquipmentItemData()
        {
            maxStackQuantity = 1;
        }

        public bool UseItem()
        {
            return false;
        }
    }
}
