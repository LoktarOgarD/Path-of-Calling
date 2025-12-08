using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public int Level { get; set; } // 1–5
        public string GodName { get; set; } = "";
        public string Text { get; set; } = "";
        
        // Archetyp-Gewichte, z. B. { "Viking" → 1.0, "Bard" → 0.5 }
        public Dictionary<string, double> ArchetypeWeights { get; set; } =
            new Dictionary<string, double>();
    }
}
