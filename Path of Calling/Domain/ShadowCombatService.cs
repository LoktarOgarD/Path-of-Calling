using System;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    public static class ShadowCombatService
    {
        private const int DicePoolPerRound = 6;

        /// <summary>
        /// Kampf gegen kleinen Schatten nach jedem Level (1–4).
        /// Spieler kann einmal pro Kampf eine reale Aufgabe melden und 2 Bonuspunkte verteilen.
        /// </summary>
        public static bool RunMinorShadowFight(Player player, ShadowEnemy enemy)
        {
            return RunShadowFightInternal(player, enemy, isFinalShadow: false);
        }

        /// <summary>
        /// Kampf gegen großen Archetyp-Schatten nach Level 5.
        /// Wenn Spieler gewinnt und reale Aufgabe bestätigt → UltimateUnlocked = true.
        /// </summary>
        public static bool RunFinalShadowFight(Player player, ShadowEnemy enemy)
        {
            bool result = RunShadowFightInternal(player, enemy, isFinalShadow: true);

            if (result)
            {
                Console.WriteLine("\nDer Schatten fragt dich:");
                Console.WriteLine("Hast du deine reale Prüfungsaufgabe für heute wirklich erfüllt? (j/n)");
                Console.Write("> ");
                var key = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(key) && key.Trim().ToLower().StartsWith("j"))
                {
                    player.UltimateUnlocked = true;
                    Console.WriteLine("\nDein Wille wurde anerkannt. Deine Ultimate-Fähigkeit wird freigeschaltet.");
                }
                else
                {
                    Console.WriteLine("\nDu hast den Schatten besiegt, aber die Götter spüren, dass die Aufgabe unvollständig ist.");
                    Console.WriteLine("Die Ultimate bleibt vorerst verschlossen.");
                }
            }

            return result;
        }

        private static bool RunShadowFightInternal(Player player, ShadowEnemy enemy, bool isFinalShadow)
        {
            var random = new Random();

            int playerHp     = 10 + player.Stats[StatType.Strength];      // einfache Kopplung an Stats
            int baseAttack   = 3  + player.Stats[StatType.Strength] / 2;
            int baseDefense  = 3  + player.Stats[StatType.Discipline] / 2;

            int enemyHp      = enemy.Hp;
            int enemyAttack  = enemy.AttackPower;
            int enemyDefense = enemy.DefensePower;

            bool bonusUsed       = false;
            int bonusAttackPerm  = 0;
            int bonusDefensePerm = 0;

            Console.Clear();
            Console.WriteLine(isFinalShadow
                ? $"=== Letzter Schattenkampf: {enemy.Name} ({enemy.Title}) ==="
                : $"=== Kampf gegen inneren Schatten: {enemy.Name} ({enemy.Title}) ===");
            Console.WriteLine(enemy.Description);
            Console.WriteLine();

            while (playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine($"Spieler HP: {playerHp} | Schatten HP: {enemyHp}");
                Console.WriteLine($"Basis: Angriff {baseAttack}+{bonusAttackPerm}, Verteidigung {baseDefense}+{bonusDefensePerm}");
                Console.WriteLine();
                Console.WriteLine("Wähle deine Haltung für diese Runde:");
                Console.WriteLine("1) Aggressiv    (4 Würfel Angriff, 2 Verteidigung)");
                Console.WriteLine("2) Ausgeglichen (3 Würfel Angriff, 3 Verteidigung)");
                Console.WriteLine("3) Defensiv     (2 Würfel Angriff, 4 Verteidigung)");
                if (!bonusUsed)
                    Console.WriteLine("4) Ich habe meine reale Aufgabe erledigt (Bonus +2 permanent verteilen)");
                Console.Write("> ");
                string? input = Console.ReadLine();

                int playerAttackDice = 0;
                int playerDefenseDice = 0;

                if (input == "1")
                {
                    playerAttackDice = 4;
                    playerDefenseDice = 2;
                }
                else if (input == "2")
                {
                    playerAttackDice = 3;
                    playerDefenseDice = 3;
                }
                else if (input == "3")
                {
                    playerAttackDice = 2;
                    playerDefenseDice = 4;
                }
                else if (input == "4" && !bonusUsed)
                {
                    Console.WriteLine("\nWelche reale Aufgabe hast du erledigt?");
                    Console.Write("> ");
                    string? quest = Console.ReadLine();
                    Console.WriteLine("\nDu erhältst 2 Bonuspunkte. Wie möchtest du sie verteilen?");
                    Console.WriteLine("1) +2 Angriff");
                    Console.WriteLine("2) +2 Verteidigung");
                    Console.WriteLine("3) +1 Angriff, +1 Verteidigung");
                    Console.Write("> ");
                    string? bonusChoice = Console.ReadLine();

                    switch (bonusChoice)
                    {
                        case "1":
                            bonusAttackPerm += 2;
                            break;
                        case "2":
                            bonusDefensePerm += 2;
                            break;
                        default:
                            bonusAttackPerm += 1;
                            bonusDefensePerm += 1;
                            break;
                    }

                    bonusUsed = true;
                    Console.WriteLine("\nDie Götter haben deinen Einsatz in der echten Welt gespürt.");
                    Console.WriteLine("Deine Werte steigen für den Rest des Kampfes.\n");
                    continue; // Runde neu mit neuer Haltung wählen
                }
                else
                {
                    Console.WriteLine("\nUnklare Eingabe, du kämpfst ausgeglichen.");
                    playerAttackDice = 3;
                    playerDefenseDice = 3;
                }

                // Gegner verteilt symmetrisch (einfacher MVP)
                int enemyAttackDice = 3;
                int enemyDefenseDice = 3;

                // --- Spieler greift an ---
                int playerAttackRoll = baseAttack + bonusAttackPerm + RollDice(random, playerAttackDice);
                int enemyDefenseRoll = enemyDefense + RollDice(random, enemyDefenseDice);

                int damageToEnemy = Math.Max(0, playerAttackRoll - enemyDefenseRoll);
                if (damageToEnemy > 0)
                {
                    enemyHp -= damageToEnemy;
                    Console.WriteLine($"\nDu triffst den Schatten für {damageToEnemy} Schaden!");
                    if (enemyHp < 0) enemyHp = 0;
                }
                else
                {
                    Console.WriteLine("\nDein Angriff prallt an der Dunkelheit ab.");
                }

                if (enemyHp <= 0)
                    break;

                // --- Schatten greift an ---
                int enemyAttackRoll = enemyAttack + RollDice(random, enemyAttackDice);
                int playerDefenseRoll = baseDefense + bonusDefensePerm + RollDice(random, playerDefenseDice);

                int damageToPlayer = Math.Max(0, enemyAttackRoll - playerDefenseRoll);
                if (damageToPlayer > 0)
                {
                    playerHp -= damageToPlayer;
                    Console.WriteLine($"Der Schatten trifft dich für {damageToPlayer} Schaden!");
                    if (playerHp < 0) playerHp = 0;
                }
                else
                {
                    Console.WriteLine("Du parierst den Angriff des Schattens.");
                }

                Console.WriteLine("\nDrücke eine Taste für die nächste Runde...");
                Console.ReadKey(true);
                Console.Clear();
            }

            if (playerHp > 0)
            {
                Console.WriteLine($"\nDu hast {enemy.Name} besiegt.");
                return true;
            }

            Console.WriteLine($"\nDu wurdest von {enemy.Name} überwältigt.");
            return false;
        }

        private static int RollDice(Random random, int count)
        {
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += random.Next(1, 7); // W6
            }
            return sum;
        }
    }
}
