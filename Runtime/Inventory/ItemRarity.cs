using System.IO;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Rarity Tier")]
    public class ItemRarity : ScriptableObject
    {
        [SerializeField] private new string name = "New Rarity Tier Name";
        [SerializeField] private int rank = 0;
        [SerializeField] private Color color = Color.white;

        public string Name => name;
        public int Rank => rank;
        public Color Color => color;

        private void OnValidate()
        {
            name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
        }
    }
}
