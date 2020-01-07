namespace blai30.RPGSystems.Stats
{
    public interface IStat
    {
        float Value { get; }

        void UpdateBaseValue(float newValue);
        void AddModifier(StatModifier modifier);
        bool RemoveModifier(StatModifier modifier);
    }
}
