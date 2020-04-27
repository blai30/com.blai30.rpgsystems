using System.IO;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Combat
{
    [CreateAssetMenu(menuName = "RPG Systems/Combat/Damage Type", order = 0)]
    public class DamageType : ScriptableObject
    {
        [SerializeField] private new string name = "New Damage Type Name";
        [SerializeField] private Color color = Color.white;
        [SerializeField] private Sprite icon = null;

        public string Name => name;
        public Color Color => color;
        public Sprite Sprite => icon;

        private void OnValidate()
        {
            name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
        }
    }
}
