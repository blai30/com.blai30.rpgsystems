using blai30.RPGSystems.Combat;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Weapon Item", order = 1)]
    public class WeaponItem : EquipmentItem
    {
        [Header("Weapon Item")]
        [SerializeField] private WeaponType weaponType = null;
        [SerializeField] private DamageType damageType = null;
    }
}
