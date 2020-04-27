using System.IO;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Stats
{
    [CreateAssetMenu(menuName = "RPG Systems/Stats/Stat Type")]
    public class StatType : ScriptableObject, IStatType
    {
        [SerializeField] private new string name = "New Stat Type Name";
        [SerializeField] private float defaultValue = 0f;

        public string Name => name;
        public float DefaultValue => defaultValue;

        private void OnValidate()
        {
            name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
        }
    }
}
