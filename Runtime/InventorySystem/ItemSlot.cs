using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace blai30.RPGSystems.InventorySystem
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image image;

        public event Action<Item> OnRightClickEvent;

        public Item item
        {
            get => m_Item;
            set
            {
                m_Item = value;
                if (m_Item == null)
                {
                    image.enabled = false;
                }
                else
                {
                    image.sprite = m_Item.itemIcon;
                    image.enabled = true;
                }
            }
        }

        private Item m_Item;

        protected virtual void OnValidate()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
            {
                if (item != null)
                {
                    OnRightClickEvent?.Invoke(item);
                }
            }
        }
    }
}
