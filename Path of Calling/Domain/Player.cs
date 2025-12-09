using System;
using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class Player
    {
        public string Name { get; set; } = "Wanderer";

        // wird nach dem Test gesetzt: "Knight" / "Samurai" / "Viking" / "Bard"
        public string ArchetypeId { get; set; } = "";

        public int Level { get; set; } = 1;

        // 5 Kern-Stats (Strength, Discipline, Courage, Wisdom, Creativity)
        public Dictionary<StatType, int> Stats { get; set; }

        // Ultimate-Status
        public bool UltimateUnlocked { get; set; } = false;
        public string UltimateName { get; set; } = "";

        public Player()
        {
            // Alle Stats sauber auf 0 initialisieren
            Stats = new Dictionary<StatType, int>();
            foreach (StatType stat in (StatType[])Enum.GetValues(typeof(StatType)))
            {
                Stats[stat] = 0;
            }
        }
    }
}
