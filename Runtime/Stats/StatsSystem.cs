using System.Collections.Generic;

namespace blai30.RPGSystems.Stats
{
    public class StatsSystem
    {
        private readonly Dictionary<IStatType, Stat> _stats = new Dictionary<IStatType, Stat>();

        public StatsSystem()
        {
        }

        public StatsSystem(BaseStats baseStats)
        {
            foreach (BaseStats.BaseStat stat in baseStats.Stats)
            {
                _stats.Add(stat.StatType, new Stat(stat.Value));
            }
        }

        public void AddModifier(IStatType type, StatModifier modifier)
        {
            if (!_stats.TryGetValue(type, out Stat stat))
            {
                stat = new Stat(type);
                _stats.Add(type, stat);
            }
            stat.AddModifier(modifier);
        }

        public bool RemoveModifier(IStatType type, StatModifier modifier)
        {
            return _stats.TryGetValue(type, out Stat stat) && stat.RemoveModifier(modifier);
        }

        public Stat GetStat(IStatType type)
        {
            if (!_stats.TryGetValue(type, out Stat stat))
            {
                stat = new Stat(type);
                _stats.Add(type, stat);
            }

            return stat;
        }

        public float GetStatValue(IStatType type)
        {
            if (!_stats.TryGetValue(type, out Stat stat))
            {
                stat = new Stat(type);
                _stats.Add(type, stat);
            }

            return stat.Value;
        }
    }
}
