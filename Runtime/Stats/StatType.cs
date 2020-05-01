using UnityEngine;

namespace blai30.RPGSystems.Stats
{
    [CreateAssetMenu(menuName = "RPG Systems/Stats/Stat Type")]
    public class StatType : ScriptableObject, IStatType
    {
        [SerializeField] private string statName = "New Stat Type Name";
        [SerializeField] private string abbreviation = "ABC";
        [SerializeField] private float defaultValue = 0f;

        public string Name => statName;
        public string Abbreviation => abbreviation;
        public float DefaultValue => defaultValue;
    }
}
