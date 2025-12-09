using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    /// Art des Angriffs – für Menü & Logik.
    public enum MoveType
    {
        Light,
        Heavy,
        Skill,
        Ultimate
    }
    /// Ein einzelner Combat Move (Schlag/Fähigkeit).
    /// </summary>
    public class CombatMove
    {
        public string Id { get; set; } = "";
        public string ArchetypeId { get; set; } = ""; // Knight / Samurai / Viking / Bard
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public MoveType Type { get; set; }
        /// Basis-Schaden des Moves (vor Stat-Boni).
        public int Power { get; set; }
        /// Trefferchance in Prozent (0–100). MVP: Kannst du später verwenden
        public int Accuracy { get; set; }
    }

    /// Statische Definition aller Moves für die 4 Archetypen
    /// (Light / Heavy / Skill / Ultimate).
    public static class CombatMoveRepository
    {
        private const string KNIGHT  = "Knight";
        private const string SAMURAI = "Samurai";
        private const string VIKING  = "Viking";
        private const string BARD    = "Bard";

        private static readonly List<CombatMove> AllMoves = new List<CombatMove>
        {
            //  KNIGHT (St. Michael – Ehre, Schutz) 
            new CombatMove
            {
                Id = "Knight_Light",
                ArchetypeId = KNIGHT,
                Type = MoveType.Light,
                Name = "Shield Bash",
                Description = "Ein schneller Schlag mit dem Schild. Solide, zuverlässig.",
                Power = 4,
                Accuracy = 90
            },
            new CombatMove
            {
                Id = "Knight_Heavy",
                ArchetypeId = KNIGHT,
                Type = MoveType.Heavy,
                Name = "Holy Strike",
                Description = "Ein kraftvoller Hieb, durchdrungen von Pflicht und Licht.",
                Power = 7,
                Accuracy = 75
            },
            new CombatMove
            {
                Id = "Knight_Skill",
                ArchetypeId = KNIGHT,
                Type = MoveType.Skill,
                Name = "Guardian Stance",
                Description = "Du nimmst eine defensive Haltung ein und stärkst deine Verteidigung.",
                Power = 0,
                Accuracy = 100
            },
            new CombatMove
            {
                Id = "Knight_Ultimate",
                ArchetypeId = KNIGHT,
                Type = MoveType.Ultimate,
                Name = "Judgement of Light",
                Description = "St. Michael richtet ein göttliches Urteil – ein massiver Schlag gegen das Dunkel.",
                Power = 12,
                Accuracy = 80
            },

            //  SAMURAI (Hachiman – Disziplin, Fokus) 
            new CombatMove
            {
                Id = "Samurai_Light",
                ArchetypeId = SAMURAI,
                Type = MoveType.Light,
                Name = "Focused Cut",
                Description = "Ein präziser, kontrollierter Schlag.",
                Power = 4,
                Accuracy = 95
            },
            new CombatMove
            {
                Id = "Samurai_Heavy",
                ArchetypeId = SAMURAI,
                Type = MoveType.Heavy,
                Name = "Iaijutsu Slash",
                Description = "Ein schneller, tödlicher Zieh-Schnitt aus der Scheide.",
                Power = 8,
                Accuracy = 70
            },
            new CombatMove
            {
                Id = "Samurai_Skill",
                ArchetypeId = SAMURAI,
                Type = MoveType.Skill,
                Name = "Meditative Parry",
                Description = "Du fokussierst dich und parierst kommende Angriffe besser.",
                Power = 0,
                Accuracy = 100
            },
            new CombatMove
            {
                Id = "Samurai_Ultimate",
                ArchetypeId = SAMURAI,
                Type = MoveType.Ultimate,
                Name = "Perfect Draw",
                Description = "Ein nahezu perfekter Schnitt – Hachiman führt deine Klinge.",
                Power = 13,
                Accuracy = 85
            },

            //  VIKING (Thor – Wut, rohe Kraft) 
            new CombatMove
            {
                Id = "Viking_Light",
                ArchetypeId = VIKING,
                Type = MoveType.Light,
                Name = "Axe Swing",
                Description = "Ein wilder Hieb mit der Axt.",
                Power = 5,
                Accuracy = 90
            },
            new CombatMove
            {
                Id = "Viking_Heavy",
                ArchetypeId = VIKING,
                Type = MoveType.Heavy,
                Name = "Berserker Smash",
                Description = "Ein brutaler Schlag, der alles auf eine Karte setzt.",
                Power = 9,
                Accuracy = 70
            },
            new CombatMove
            {
                Id = "Viking_Skill",
                ArchetypeId = VIKING,
                Type = MoveType.Skill,
                Name = "War Cry",
                Description = "Ein Kampfschrei, der deine Angriffskraft steigert.",
                Power = 0,
                Accuracy = 100
            },
            new CombatMove
            {
                Id = "Viking_Ultimate",
                ArchetypeId = VIKING,
                Type = MoveType.Ultimate,
                Name = "Ragnarok Charge",
                Description = "Ein todesmutiger Sturmangriff, gesegnet von Thor.",
                Power = 14,
                Accuracy = 75
            },

            //  BARD (Hermes – Inspiration, Kommunikation) 
            {
                Id = "Bard_Light",
                ArchetypeId = BARD,
                Type = MoveType.Light,
                Name = "Inspiring Note",
                Description = "Ein leichter Schlag, begleitet von einem inspirierenden Ton.",
                Power = 3,
                Accuracy = 100
            },
            new CombatMove
            {
                Id = "Bard_Heavy",
                ArchetypeId = BARD,
                Type = MoveType.Heavy,
                Name = "Sonic Strike",
                Description = "Ein kräftiger Klangstoß, der den Gegner schwächt.",
                Power = 6,
                Accuracy = 80
            },
            new CombatMove
            {
                Id = "Bard_Skill",
                ArchetypeId = BARD,
                Type = MoveType.Skill,
                Name = "Crowd Charm",
                Description = "Du spielst auf deine soziale Stärke – stellst das Gleichgewicht leicht zu deinen Gunsten.",
                Power = 0,
                Accuracy = 100
            },
            new CombatMove
            {
                Id = "Bard_Ultimate",
                ArchetypeId = BARD,
                Type = MoveType.Ultimate,
                Name = "Anthem of the Gods",
                Description = "Ein hymnischer Ruf, Hermes selbst scheint mitzusingen.",
                Power = 11,
                Accuracy = 90
            },
        };

        public static List<CombatMove> GetMovesForArchetype(string archetypeId)
        {
            var list = new List<CombatMove>();
            foreach (var move in AllMoves)
            {
                if (move.ArchetypeId == archetypeId)
                    list.Add(move);
            }
            return list;
        }

        public static CombatMove? GetUltimateForArchetype(string archetypeId)
        {
            foreach (var move in AllMoves)
            {
                if (move.ArchetypeId == archetypeId && move.Type == MoveType.Ultimate)
                    return move;
            }
            return null;
        }
    }
}
