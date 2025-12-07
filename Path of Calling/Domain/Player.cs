using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class Player
    {
        public string Name { get; set; } = "Wanderer";
        public string ArchetypeId { get; set; } = "Knight";
        public int Level { get; set; } = 1;

        // 10 Punkte Basis, später +5 durch Level
        public Dictionary<StatType, int> Stats { get; set; } =
            new Dictionary<StatType, int>
            {
                { StatType.Strength, 0 },
                { StatType.Discipline, 0 },
                { StatType.Courage, 0 },
                { StatType.Wisdom, 0 },
                { StatType.Creativity, 0 }
            };

        public bool UltimateUnlocked { get; set; } = false;
        public string UltimateName { get; set; } = "";
    }
}
