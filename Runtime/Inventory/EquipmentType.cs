using System.IO;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Equipment Type")]
    public class EquipmentType : ScriptableObject
    {
        [SerializeField] private new string name = "New Equipment Type Name";
        [SerializeField] private Sprite icon = null;

        public string Name => name;
        public Sprite Sprite => icon;

        private void OnValidate()
        {
            name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
        }
    }
}
