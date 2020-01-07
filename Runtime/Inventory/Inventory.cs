using System;
using System.Collections.Generic;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> items = null;
        [SerializeField] private Transform itemsParent = null;
        [SerializeField] private ItemSlot[] itemSlots;

        public event Action<Item> OnItemRightClickedEvent;

        private void Awake()
        {
            foreach (ItemSlot slot in itemSlots)
            {
                slot.OnRightClickEvent += OnItemRightClickedEvent;
            }
        }

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

        public bool AddItem(Item item)
        {
            if (IsFull())
            {
                return false;
            }
            items.Add(item);
            RefreshUi();
            return true;
        }

        public bool RemoveItem(Item item)
        {
            if (!items.Remove(item))
            {
                return false;
            }
            RefreshUi();
            return true;

        }

        public bool IsFull()
        {
            return items.Count >= itemSlots.Length;
        }
    }
}
