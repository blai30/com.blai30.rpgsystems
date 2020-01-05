using UnityEngine;

namespace blai30.RPGSystems.StatsSystem
{
    public class StatPanel : MonoBehaviour
    {
        [SerializeField] private StatDisplay[] statDisplays;
        [SerializeField] private string[] statNames;

        private Stat[] m_Stats;

        private void OnValidate()
        {
            statDisplays = GetComponentsInChildren<StatDisplay>();
            UpdateStatNames();
        }

        public void SetStats(params Stat[] stats)
        {
            m_Stats = stats;

            if (m_Stats.Length > statDisplays.Length)
            {
                Debug.LogError("Not enough stat displays");
                return;
            }

            for (int i = 0; i < statDisplays.Length; i++)
            {
                statDisplays[i].gameObject.SetActive(i < statDisplays.Length);
            }
        }

        public void UpdateStatValues()
        {
            for (int i = 0; i < m_Stats.Length; i++)
            {
                statDisplays[i].valueText.text = m_Stats[i].value.ToString();
            }
        }

        public void UpdateStatNames()
        {
            for (int i = 0; i < statNames.Length; i++)
            {
                statDisplays[i].nameText.text = statNames[i];
            }
        }
    }
}
