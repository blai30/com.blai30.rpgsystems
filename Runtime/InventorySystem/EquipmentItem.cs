using UnityEngine;

namespace blai30.RPGSystems.InventorySystem
{
    public enum EquipmentType
    {
        Helmet,
        Chest,
        Gloves,
        Boots,
        WeaponMain,
        WeaponSub,
        Face,
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
        public EquipmentType equimentType;
    }
}
