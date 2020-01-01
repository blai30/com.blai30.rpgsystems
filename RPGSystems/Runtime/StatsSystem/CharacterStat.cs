using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace blai30.RPGSystems.StatsSystem
{
    [Serializable]
    public class CharacterStat
    {
        public float BaseValue;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;
        public virtual float Value
        {
            get
            {
                if (!m_IsDirty && m_LastBaseValue == BaseValue) return m_Value;
                m_LastBaseValue = BaseValue;
                m_Value = CalculateFinalValue();
                m_IsDirty = false;

                return m_Value;
            }
        }

        protected readonly List<StatModifier> m_StatModifiers;
        protected bool m_IsDirty = true;
        protected float m_Value;
        protected float m_LastBaseValue = float.MinValue;

        public CharacterStat()
        {
            m_StatModifiers = new List<StatModifier>();
            StatModifiers = m_StatModifiers.AsReadOnly();
        }

        /// <summary>
        /// Initialize a new character stat with a default base value.
        /// </summary>
        /// <param name="baseValue">Default value of the stat</param>
        public CharacterStat(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        /// <summary>
        /// Add a stat modifier to the list of modifiers for calculation.
        /// </summary>
        /// <param name="modifier">Stat modifier to be added</param>
        public virtual void AddModifier(StatModifier modifier)
        {
            m_IsDirty = true;
            m_StatModifiers.Add(modifier);
            m_StatModifiers.Sort(CompareModifierOrder);
        }

        /// <summary>
        /// Remove a stat modifier from the list of modifiers for calculation.
        /// </summary>
        /// <param name="modifier">Stat modifier to be removed</param>
        /// <returns>Successful procedure</returns>
        public virtual bool RemoveModifier(StatModifier modifier)
        {
            if (!m_StatModifiers.Remove(modifier)) return false;
            m_IsDirty = true;
            return true;

        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = m_StatModifiers.Count; i >= 0; i--)
            {
                if (m_StatModifiers[i].Source == source)
                {
                    m_IsDirty = true;
                    didRemove = true;
                    m_StatModifiers.RemoveAt(i);
                }
            }

            return didRemove;
        }

        /// <summary>
        /// Calculate the final value of the stat applying all modifiers.
        /// </summary>
        /// <returns>The final value of the stat</returns>
        protected virtual float CalculateFinalValue()
        {
            // foreach statModifier in m_StatModifiers, BaseValue += statModifier.Value
            float finalValue = BaseValue;
            float sumPercentAdditive = 0;

            for (int i = 0; i < m_StatModifiers.Count; i++)
            {
                StatModifier mod = m_StatModifiers[i];
                switch (mod.Type)
                {
                    case StatModifierType.Flat:
                        finalValue += mod.Value;
                        break;
                    case StatModifierType.PercentAdditive:
                        sumPercentAdditive += mod.Value;
                        if (i + 1 >= m_StatModifiers.Count || m_StatModifiers[i + 1].Type != StatModifierType.PercentAdditive)
                        {
                            finalValue *= 1 + sumPercentAdditive;
                            sumPercentAdditive = 0;
                        }
                        break;
                    case StatModifierType.PercentMultiplicative:
                        finalValue *= 1 + mod.Value;
                        break;
                }
            }
            // Rounding gets around dumb float calculation errors (like getting 12.0001f, instead of 12f)
            // 4 significant digits is usually precise enough, but feel free to change this to fit your needs
            return (float) Math.Round(finalValue, 4);
        }

        protected virtual int CompareModifierOrder(StatModifier x, StatModifier y)
        {
            return x.Order < y.Order ? -1 : x.Order > y.Order ? 1 : 0;
        }
    }
}
