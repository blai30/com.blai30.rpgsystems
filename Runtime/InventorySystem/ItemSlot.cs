using UnityEngine;
using UnityEngine.UI;

namespace blai30.RPGSystems.InventorySystem
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image image;

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
                    image.sprite = m_Item.ItemIcon;
                    image.enabled = true;
                }
            }
        }

        private Item m_Item;

        private void OnValidate()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }
    }
}
