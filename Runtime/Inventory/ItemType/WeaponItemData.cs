using blai30.RPGSystems.Combat;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Weapon Item", order = 1)]
    public class WeaponItemData : EquipmentItemData
    {
        #region Fields

        [SerializeField]
        protected WeaponType weaponType = null;

        [SerializeField]
        protected DamageType damageType = null;

        #endregion

        public WeaponType WeaponType => weaponType;
        public DamageType DamageType => damageType;
    }
}
