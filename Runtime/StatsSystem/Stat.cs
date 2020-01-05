using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace blai30.RPGSystems.StatsSystem
{
    [Serializable]
    public class Stat
    {
        public float baseValue;
        public readonly ReadOnlyCollection<StatModifier> statModifiers;
        public virtual float value
        {
            get
            {
                if (IsDirty || LastBaseValue != baseValue)
                {
                    LastBaseValue = baseValue;
                    Value = CalculateFinalValue();
                    IsDirty = false;
                }

                return Value;
            }
        }

        protected readonly List<StatModifier> StatModifiers;
        protected bool IsDirty = true;
        protected float Value;
        protected float LastBaseValue = float.MinValue;

        /// <summary>
        /// Initialize a new character stat.
        /// </summary>
        public Stat()
        {
            StatModifiers = new List<StatModifier>();
            statModifiers = StatModifiers.AsReadOnly();
        }

        /// <summary>
        /// Initialize a new character stat with a default base value.
        /// </summary>
        /// <param name="baseValue">Default value of the stat</param>
        public Stat(float baseValue) : this()
        {
            this.baseValue = baseValue;
        }

        /// <summary>
        /// Add a stat modifier to the list of modifiers for calculation.
        /// </summary>
        /// <param name="modifier">Stat modifier to be added</param>
        public virtual void AddModifier(StatModifier modifier)
        {
            IsDirty = true;
            int index = StatModifiers.BinarySearch(modifier, new ByPriority());
            if (index < 0)
            {
                index = ~index;
            }
            StatModifiers.Insert(index, modifier);
        }

        /// <summary>
        /// Remove a stat modifier from the list of modifiers for calculation.
        /// </summary>
        /// <param name="modifier">Stat modifier to be removed</param>
        /// <returns>Successful procedure</returns>
        public virtual bool RemoveModifier(StatModifier modifier)
        {
            if (!StatModifiers.Remove(modifier))
            {
                return false;
            }
            IsDirty = true;
            return true;

        }

        /// <summary>
        /// Removes all stat modifiers from the source.
        /// </summary>
        /// <param name="source">Source to remove all stat modifiers from</param>
        /// <returns>Successful procedure</returns>
        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = StatModifiers.Count - 1; i >= 0; i--)
            {
                if (StatModifiers[i].Source == source)
                {
                    IsDirty = true;
                    didRemove = true;
                    StatModifiers.RemoveAt(i);
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
            float finalValue = baseValue;
            float sumPercentAdditive = 0;

            for (int i = 0; i < StatModifiers.Count; i++)
            {
                StatModifier mod = StatModifiers[i];
                switch (mod.Type)
                {
                    case StatModifierType.Flat:
                        finalValue += mod.Value;
                        break;
                    case StatModifierType.PercentAdditive:
                        sumPercentAdditive += mod.Value;
                        if (i + 1 >= StatModifiers.Count || StatModifiers[i + 1].Type != StatModifierType.PercentAdditive)
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

        /// <summary>
        /// Compares the order of two stat modifiers.
        /// </summary>
        /// <param name="x">First stat modifier</param>
        /// <param name="y">Second stat modifier</param>
        /// <returns>The order of x and y</returns>
        // protected virtual int CompareModifierOrder(StatModifier x, StatModifier y)
        // {
        //     return x.Order < y.Order ? -1 : x.Order > y.Order ? 1 : 0;
        // }
        private class ByPriority : IComparer<StatModifier>
        {
            public int Compare(StatModifier x, StatModifier y)
            {
                return x.Order < y.Order ? -1 : x.Order > y.Order ? 1 : 0;
            }
        }
    }
}
