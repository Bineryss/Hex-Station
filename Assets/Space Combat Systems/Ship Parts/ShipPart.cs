
public interface ShipPart
{
    public StatModifiers BaseModifiers { get; }
}




[System.Serializable]
public struct StatModifiers
{
    public float healthMultiplier;
    public float speedMultiplier;
    public float damageMultiplier;
    public float costMultiplier;

    // Combine modifiers multiplicatively
    public static StatModifiers operator *(StatModifiers a, StatModifiers b)
    {
        return new StatModifiers
        {
            healthMultiplier = a.healthMultiplier * b.healthMultiplier,
            speedMultiplier = a.speedMultiplier * b.speedMultiplier,
            damageMultiplier = a.damageMultiplier * b.damageMultiplier,
            costMultiplier = a.costMultiplier * b.costMultiplier
        };
    }
}