using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class Player
    {
        public string Name { get; set; } = "Wanderer";

        // Назначается после Personality Test
        public string ArchetypeId { get; set; } = "";

        // Уровни 1–5 (испытания)
        public int Level { get; set; } = 1;

        // Основные характеристики
        public Dictionary<StatType, int> Stats { get; set; } =
            new Dictionary<StatType, int>
            {
                { StatType.Strength, 0 },
                { StatType.Discipline, 0 },
                { StatType.Courage, 0 },
                { StatType.Wisdom, 0 },
                { StatType.Creativity, 0 }
            };

        // === Финальная механика ===
        public bool UltimateUnlocked { get; set; } = false;
        public string UltimateName { get; set; } = "";
    }
}
