using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu(menuName = "RPG Systems/Inventory/Rarity Tier")]
    public class RarityTier : ScriptableObject
    {
        [SerializeField] private string rarityName = "New Rarity Tier Name";
        [SerializeField] private int rank = 0;
        [SerializeField] private Color color = Color.white;

        public string RarityName => rarityName;
        public int Rank => rank;
        public Color Color => color;
    }
}
