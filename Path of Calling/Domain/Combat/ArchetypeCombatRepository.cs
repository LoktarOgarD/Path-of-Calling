using System.Collections.Generic;

namespace PathOfCalling.Domain.Combat
{
    public static class ArchetypeCombatRepository
    {
        public static List<CombatMove> GetMoves(string archetypeId, bool ultimateUnlocked)
        {
            var moves = archetypeId switch
            {
                "Knight"  => KnightMoves(),
                "Samurai" => SamuraiMoves(),
                "Viking"  => VikingMoves(),
                "Bard"    => BardMoves(),
                _         => new List<CombatMove>()
            };

            if (!ultimateUnlocked)
                moves.RemoveAll(m => m.Type == MoveType.Ultimate);

            return moves;
        }

        private static List<CombatMove> KnightMoves() => new()
        {
            new CombatMove { Name="Shield Strike",    Type=MoveType.Light,    AttackPower=3, DefensePower=2, Description="Schneller Schlag mit Schild." },
            new CombatMove { Name="Oath Slash",       Type=MoveType.Heavy,    AttackPower=5, DefensePower=1, Description="Schwerer Schlag im Namen des Eides." },
            new CombatMove { Name="Guardian Stance",  Type=MoveType.Skill,    AttackPower=1, DefensePower=4, Description="Defensive Haltung, Fokus auf Schutz." },
            new CombatMove { Name="Judgement of Light", Type=MoveType.Ultimate, AttackPower=8, DefensePower=4, Description="Heiliger Schlag gegen die Dunkelheit." }
        };

        private static List<CombatMove> SamuraiMoves() => new()
        {
            new CombatMove { Name="Iaido Cut",        Type=MoveType.Light,    AttackPower=4, DefensePower=1, Description="Präziser Iaido-Schnitt." },
            new CombatMove { Name="Focused Slash",    Type=MoveType.Heavy,    AttackPower=6, DefensePower=0, Description="Konzentrierter, tödlicher Hieb." },
            new CombatMove { Name="Meditative Guard", Type=MoveType.Skill,    AttackPower=1, DefensePower=4, Description="Ruhige, fokussierte Verteidigung." },
            new CombatMove { Name="Perfect Void",     Type=MoveType.Ultimate, AttackPower=9, DefensePower=3, Description="Perfekter Schlag aus innerer Leere." }
        };

        private static List<CombatMove> VikingMoves() => new()
        {
            new CombatMove { Name="Axe Swing",        Type=MoveType.Light,    AttackPower=4, DefensePower=1, Description="Wilder Hieb mit der Axt." },
            new CombatMove { Name="Rage Cleave",      Type=MoveType.Heavy,    AttackPower=7, DefensePower=0, Description="Wuchtiger Schlag aus purer Wut." },
            new CombatMove { Name="War Cry",          Type=MoveType.Skill,    AttackPower=2, DefensePower=3, Description="Kampfschrei stärkt deinen Kampfgeist." },
            new CombatMove { Name="Wrath of Thor",    Type=MoveType.Ultimate, AttackPower=10, DefensePower=2, Description="Donnernder Angriff im Namen Thors." }
        };

        private static List<CombatMove> BardMoves() => new()
        {
            new CombatMove { Name="Mocking Verse",    Type=MoveType.Light,    AttackPower=3, DefensePower=2, Description="Spöttischer Vers, der den Feind irritiert." },
            new CombatMove { Name="Inspiring Anthem", Type=MoveType.Heavy,    AttackPower=5, DefensePower=2, Description="Starker Gesang, der Kraft verleiht." },
            new CombatMove { Name="Soothing Melody",  Type=MoveType.Skill,    AttackPower=1, DefensePower=4, Description="Beruhigende Melodie, stabilisiert dich." },
            new CombatMove { Name="Symphony of Souls",Type=MoveType.Ultimate, AttackPower=7, DefensePower=5, Description="Große Hymne, die den Kampf wendet." }
        };
    }
}
