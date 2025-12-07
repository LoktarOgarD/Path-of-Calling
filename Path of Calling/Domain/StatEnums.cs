namespace PathOfCalling.Domain
{
    // Persönliche Entwicklungs-Stats des Spielers
    public enum StatType
    {
        Strength,     // Stärke
        Discipline,   // Disziplin
        Courage,      // Mut
        Wisdom,       // Weisheit
        Creativity    // Kreativität
    }

    // Statuswerte für die Götter im Kampf
    public enum GodStatType
    {
        Vitality, // Leben
        Might,    // physischer Schaden
        Guard,    // Verteidigung
        Speed,    // Initiative
        Focus     // geistige/magische Kraft
    }

    public enum Temperament
    {
        Melancholic,
        Phlegmatic,
        Choleric,
        Sanguine
    }
}
