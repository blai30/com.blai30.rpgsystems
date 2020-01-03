using System.Collections.Generic;
using UnityEngine;

namespace blai30.RPGSystems.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> items;
        [SerializeField] private Transform itemsParent;
        [SerializeField] private ItemSlot[] itemSlots;

        private void OnValidate()
        {
            if (itemsParent != null)
            {
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
            }
            RefreshUi();
        }

        private void RefreshUi()
        {
            int i = 0;
            for (; i < items.Count && i < itemSlots.Length; i++)
            {
                itemSlots[i].item = items[i];
            }

            for (; i < itemSlots.Length; i++)
            {
                itemSlots[i].item = null;
            }
        }
    }
}
