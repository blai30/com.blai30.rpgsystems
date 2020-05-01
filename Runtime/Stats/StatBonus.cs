using System;
using UnityEngine;

namespace blai30.RPGSystems.Stats
{
    [Serializable]
    public class StatBonus
    {
        [SerializeField]
        private StatType statType = null;
        [SerializeField]
        private StatModifierType modifierType = 0;
        [SerializeField]
        private float value = 0f;

        public StatType StatType => statType;
        public StatModifierType ModifierType => modifierType;
        public float Value => value;
    }
}
