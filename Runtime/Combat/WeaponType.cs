using System.IO;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Combat
{
    [CreateAssetMenu(menuName = "RPG Systems/Combat/Weapon Type", order = 1)]
    public class WeaponType : ScriptableObject
    {
        [SerializeField] private new string name = "New Weapon Type Name";
        [SerializeField] private Sprite icon = null;

        public string Name => name;
        public Sprite Sprite => icon;
    }
}
