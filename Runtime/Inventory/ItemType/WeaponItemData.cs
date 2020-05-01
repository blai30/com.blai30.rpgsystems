using blai30.RPGSystems.Combat;
using Sirenix.OdinInspector;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Weapon Item", order = 1)]
    public class WeaponItemData : EquipmentItemData
    {
        protected const string GROUP_WEAPON = "Weapon";

        #region Fields

        [SerializeField]
        [BoxGroup(GROUP_WEAPON)]
        [AssetSelector(DropdownTitle = "Weapon type")]
        protected WeaponType weaponType = null;

        [SerializeField]
        [BoxGroup(GROUP_WEAPON)]
        [AssetSelector(DropdownTitle = "Damage type")]
        protected DamageType damageType = null;

        #endregion

        public WeaponType WeaponType => weaponType;
        public DamageType DamageType => damageType;
    }
}
