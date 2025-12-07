using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class Deity
    {
        public string Id { get; set; }          // "Knight_God"
        public string Name { get; set; }        // "St. Michael"
        public string ArchetypeId { get; set; } // "Knight"
        public string Mythology { get; set; }   // "Christliche Tradition", "Shinto", ...
        public string Title { get; set; }       // kurze Rollenbeschreibung
        public Dictionary<GodStatType, int> Stats { get; set; } =
            new Dictionary<GodStatType, int>();
        public string Description { get; set; }
    }
}
