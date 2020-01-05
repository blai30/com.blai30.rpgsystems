using blai30.RPGSystems.StatsSystem;
using UnityEngine;

namespace blai30.RPGSystems.InventorySystem
{
    public enum EquipmentType
    {
        Helmet,
        Chest,
        Legs,
        Gloves,
        Boots,
        WeaponMain,
        WeaponSub,
        Ring,
        Earring,
        Belt
    }

    [CreateAssetMenu]
    public class EquipmentItem : Item
    {
        public int strengthBonus;
        public int dexterityBonus;
        public int intellectBonus;
        public int vitalityBonus;
        [Space]
        public float strengthPercentBonus;
        public float dexterityPercentBonus;
        public float intellectPercentBonus;
        public float vitalityPercentBonus;
        [Space]
        public EquipmentType equipmentType;

        public void Equip(Character character)
        {
            if (strengthBonus != 0)
            {
                character.strength.AddModifier(new StatModifier(strengthBonus, StatModifierType.Flat, this));
            }
            if (dexterityBonus != 0)
            {
                character.dexterity.AddModifier(new StatModifier(dexterityBonus, StatModifierType.Flat, this));
            }
            if (intellectBonus != 0)
            {
                character.intellect.AddModifier(new StatModifier(intellectBonus, StatModifierType.Flat, this));
            }
            if (vitalityBonus != 0)
            {
                character.vitality.AddModifier(new StatModifier(vitalityBonus, StatModifierType.Flat, this));
            }

            if (strengthPercentBonus != 0)
            {
                character.strength.AddModifier(new StatModifier(strengthPercentBonus, StatModifierType.PercentMultiplicative, this));
            }
            if (dexterityPercentBonus != 0)
            {
                character.dexterity.AddModifier(new StatModifier(dexterityPercentBonus, StatModifierType.PercentMultiplicative, this));
            }
            if (intellectPercentBonus != 0)
            {
                character.intellect.AddModifier(new StatModifier(intellectPercentBonus, StatModifierType.PercentMultiplicative, this));
            }
            if (vitalityPercentBonus != 0)
            {
                character.vitality.AddModifier(new StatModifier(vitalityPercentBonus, StatModifierType.PercentMultiplicative, this));
            }
        }

        public void Unequip(Character character)
        {
            character.strength.RemoveAllModifiersFromSource(this);
            character.dexterity.RemoveAllModifiersFromSource(this);
            character.intellect.RemoveAllModifiersFromSource(this);
            character.vitality.RemoveAllModifiersFromSource(this);
        }
    }
}
