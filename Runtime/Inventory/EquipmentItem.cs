using System;
using System.Collections.Generic;
using blai30.RPGSystems.Stats;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    public enum EquipmentType
    {
        WeaponMain,
        WeaponSub,
        Helmet,
        Chest,
        Legs,
        Gloves,
        Boots,
        Ring,
        Earring,
        Belt
    }

    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Equipment Item", order = 0)]
    public class EquipmentItem : Item, IEquippable
    {
        [Header("Equipment Item")]
        [SerializeField] private EquipmentType equipmentType;
        [Header("Stat bonuses")]
        [SerializeField] private List<StatBonus> statBonuses = new List<StatBonus>();

        public List<StatBonus> StatBonuses => statBonuses;

        [Serializable]
        public class StatBonus
        {
            [SerializeField] private StatType statType;
            [SerializeField] private StatModifierType modifierType;
            [SerializeField] private float value;

            public StatType StatType => statType;
            public StatModifierType ModifierType => modifierType;
            public float Value => value;
        }
    }
}
