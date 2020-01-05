using blai30.RPGSystems.StatsSystem;
using UnityEngine;

namespace blai30.RPGSystems.InventorySystem
{
    public class Character : MonoBehaviour
    {
        public Stat strength;
        public Stat dexterity;
        public Stat intellect;
        public Stat vitality;

        [SerializeField] private Inventory inventory;
        [SerializeField] private EquipmentPanel equipmentPanel;
        [SerializeField] private StatPanel statPanel;

        private void Awake()
        {
            statPanel.SetStats(strength, dexterity, intellect, vitality);
            statPanel.UpdateStatValues();
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
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
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
                item.Unequip(this);
                statPanel.UpdateStatValues();
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
