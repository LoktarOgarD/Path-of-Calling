using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class Player
    {
        public string Name { get; set; } = "Wanderer";

        public string ArchetypeId { get; set; } = "";

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
//Der Spieler startet bewusst ohne Archetyp und ohne Werte.
//Seine Entscheidungen formen ihn – nicht eine vorgegebene Klasse.
