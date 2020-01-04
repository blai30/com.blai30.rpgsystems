using System;
using UnityEngine;

namespace blai30.RPGSystems.InventorySystem
{
    public class EquipmentPanel : MonoBehaviour
    {
        [SerializeField] private Transform equipmentSlotsParent;
        [SerializeField] private EquipmentSlot[] equipmentSlots;

        public event Action<Item> OnItemRightClickedEvent;

        private void Awake()
        {
            foreach (EquipmentSlot slot in equipmentSlots)
            {
                slot.OnRightClickEvent += OnItemRightClickedEvent;
            }
        }

        private void OnValidate()
        {
            equipmentSlots = GetComponentsInChildren<EquipmentSlot>();
        }

        public bool AddItem(EquipmentItem item, out EquipmentItem previousItem)
        {
            foreach (EquipmentSlot slot in equipmentSlots)
            {
                if (slot.equipmentType != item.equimentType)
                {
                    continue;
                }

                previousItem = (EquipmentItem) slot.item;
                slot.item = item;
                return true;
            }

            previousItem = null;
            return false;
        }

        public bool RemoveItem(EquipmentItem item)
        {
            foreach (EquipmentSlot slot in equipmentSlots)
            {
                if (slot.item != item)
                {
                    continue;
                }
                slot.item = null;
                return true;
            }

            return false;
        }
    }
}
