using System.IO;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Item Category", order = 0)]
    public class ItemCategory : ScriptableObject
    {
        [SerializeField] private string categoryName = "New Category";
        [SerializeField] private Sprite categoryIcon = null;

        private void OnValidate()
        {
            categoryName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
        }
    }
}
