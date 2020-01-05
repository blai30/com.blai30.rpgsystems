using UnityEngine;
using TMPro;

namespace blai30.RPGSystems.StatsSystem
{
    public class StatDisplay : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI valueText;

        private void OnValidate()
        {
            TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
            nameText = texts[0];
            valueText = texts[1];
        }
    }
}
