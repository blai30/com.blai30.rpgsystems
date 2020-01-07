namespace blai30.RPGSystems.Inventory
{
    public class EquipmentSlot : ItemSlot
    {
        public EquipmentType equipmentType;

        protected override void OnValidate()
        {
            base.OnValidate();
            gameObject.name = equipmentType + " Slot";
        }
    }
}
