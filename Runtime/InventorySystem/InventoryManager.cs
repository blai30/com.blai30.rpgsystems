using UnityEngine;

namespace blai30.RPGSystems.InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private EquipmentPanel equipmentPanel;

        private void Awake()
        {
            inventory.OnItemRightClickedEvent += EquipFromInventory;
            equipmentPanel.OnItemRightClickedEvent += UnequipFromInventory;
        }

        public void Equip(EquipmentItem item)
        {
            if (!inventory.RemoveItem(item))
            {
                return;
            }
            EquipmentItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }

        public void Unequip(EquipmentItem item)
        {
            if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
            {
                inventory.AddItem(item);
            }
        }

        private void EquipFromInventory(Item item)
        {
            if (item is EquipmentItem equipmentItem)
            {
                Equip(equipmentItem);
            }
        }

        private void UnequipFromInventory(Item item)
        {
            if (item is EquipmentItem equipmentItem)
            {
                Unequip(equipmentItem);
            }
        }
    }
}
