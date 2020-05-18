using UnityEngine;

namespace blai30.RPGSystems.Stats
{
    public interface IStatType
    {
        string Name { get; }
        string Abbreviation { get; }
        float DefaultValue { get; }
        Sprite Icon { get; }
        Color Color { get; }
    }
}
