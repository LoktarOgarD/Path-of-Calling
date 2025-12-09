using System;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    /// <summary>
    /// Enthält die Kämpfe gegen die Schatten-Gegner.
    /// Kleine Schatten: nach jedem Level.
    /// Großer Schatten: nach dem Persönlichkeitstest (Level 5).
    /// </summary>
    public static class ShadowCombatService
    {
        /// <summary>
        /// Kampf gegen kleinen Schatten nach einem Fragen-Level.
        /// Nur Würfel + Verteilung, keine Ultimates.
        /// </summary>
        public static bool RunMinorShadowFight(Player player, ShadowEnemy enemy)
        {
            return RunShadowFightInternal(player, enemy, isFinalShadow: false);
        }

        /// <summary>
        /// Kampf gegen den großen Archetyp-Schatten.
        /// Wenn der Spieler gewinnt und seine reale Aufgabe bestätigt,
        /// wird die Ultimate-Fähigkeit freigeschaltet.
        /// </summary>
        public static bool RunFinalShadowFight(Player player, ShadowEnemy enemy)
        {
            bool result = RunShadowFightInternal(player, enemy, isFinalShadow: true);

            if (result)
            {
                Console.WriteLine();
                Console.WriteLine("Der Schatten schaut dich an und fragt:");
                Console.WriteLine("Hast du deine reale Prüfungsaufgabe für heute wirklich erfüllt? (j/n)");
                Console.Write("> ");
                string? answer = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(answer) &&
                    answer.Trim().ToLower().StartsWith("j"))
                {
                    player.UltimateUnlocked = true;
                    Console.WriteLine();
                    Console.WriteLine("Die Götter spüren deine Tat in der echten Welt.");
                    Console.WriteLine("Deine Ultimate-Fähigkeit wird freigeschaltet.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Du hast gewonnen, aber die Götter zweifeln noch.");
                    Console.WriteLine("Die Ultimate bleibt vorerst verschlossen.");
                }
            }

            return result;
        }

        /// <summary>
        /// Gemeinsame Logik für kleinen und großen Schatten-Kampf.
        /// Pro Runde: 1× W6, Spieler verteilt die Punkte auf Angriff / Verteidigung.
        /// Einmal pro Kampf: echte Aufgabe melden und +2 permanente Punkte bekommen.
        /// </summary>
        private static bool RunShadowFightInternal(Player player, ShadowEnemy enemy, bool isFinalShadow)
        {
            Random random = new Random();

            // einfache Kopplung an Werte des Spielers
            int playerHp = 10 + player.Stats[StatType.Strength];
            int baseAttack = 2 + player.Stats[StatType.Strength] / 2;
            int baseDefense = 2 + player.Stats[StatType.Discipline] / 2;

            int enemyHp = enemy.Hp;
            int enemyAttack = enemy.AttackPower;
            int enemyDefense = enemy.DefensePower;

            bool bonusUsed = false;
            int bonusAttack = 0;
            int bonusDefense = 0;

            Console.Clear();
            if (isFinalShadow)
            {
                Console.WriteLine("=== Letzter Schattenkampf ===");
            }
            else
            {
                Console.WriteLine("=== Kampf gegen inneren Schatten ===");
            }

            Console.WriteLine($"{enemy.Name} – {enemy.Title}");
            Console.WriteLine(enemy.Description);
            Console.WriteLine();
            Console.WriteLine("Pro Runde wird ein W6 gewürfelt.");
            Console.WriteLine("Du verteilst die Augen auf Angriff und Verteidigung.");
            Console.WriteLine("Einmal pro Kampf kannst du eine reale Aufgabe melden und +2 Punkte bekommen.");
            Console.WriteLine();
            Console.WriteLine("Drücke eine Taste, um zu beginnen...");
            Console.ReadKey(true);
            Console.Clear();

            int round = 1;

            while (playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine($"=== Runde {round} ===");
                Console.WriteLine($"Deine HP:   {playerHp}");
                Console.WriteLine($"Schatten HP: {enemyHp}");
                Console.WriteLine();
                Console.WriteLine($"Basiswerte (ohne Würfel):");
                Console.WriteLine($"  Angriff:    {baseAttack}  (+{bonusAttack} Bonus)");
                Console.WriteLine($"  Verteidigung: {baseDefense}  (+{bonusDefense} Bonus)");
                Console.WriteLine();

                // Möglichkeit: reale Aufgabe einlösen (nur einmal pro Kampf)
                if (!bonusUsed)
                {
                    Console.WriteLine("Möchtest du deine reale Aufgabe einlösen und +2 permanente Punkte erhalten?");
                    Console.WriteLine("1) Ja, Aufgabe erledigt");
                    Console.WriteLine("2) Nein, weiterkämpfen");
                    Console.Write("> ");
                    string? taskInput = Console.ReadLine();

                    if (taskInput == "1")
                    {
                        HandleRealWorldTask(ref bonusAttack, ref bonusDefense, ref bonusUsed);
                        Console.WriteLine("\nDrücke eine Taste, um die Runde zu beginnen...");
                        Console.ReadKey(true);
                        Console.Clear();
                        continue; // Runde neu starten, jetzt mit Bonus
                    }
                }

                // 1× W6 würfeln
                int roll = random.Next(1, 7);
                Console.WriteLine($"Du würfelst: {roll}");
                Console.WriteLine();

                int attackPoints = 0;
                int defensePoints = 0;

                // Spieler entscheidet, wie viele Punkte in Angriff gehen
                Console.WriteLine("Wie viele der Punkte möchtest du in ANGRIFF stecken?");
                Console.WriteLine($"(0 bis {roll}, der Rest geht automatisch in VERTEIDIGUNG)");
                Console.Write("> ");
                string? attackInput = Console.ReadLine();

                if (!int.TryParse(attackInput, out attackPoints))
                {
                    attackPoints = roll; // Standard: alles in Angriff
                }

                if (attackPoints < 0) attackPoints = 0;
                if (attackPoints > roll) attackPoints = roll;

                defensePoints = roll - attackPoints;

                Console.WriteLine();
                Console.WriteLine($"Verteilung dieser Runde:");
                Console.WriteLine($"  Angriffspunkte:    {attackPoints}");
                Console.WriteLine($"  Verteidigungspunkte: {defensePoints}");
                Console.WriteLine();

                // --- Spieler greift an ---
                int totalPlayerAttack = baseAttack + bonusAttack + attackPoints;
                int totalEnemyDefense = enemyDefense;

                int damageToEnemy = totalPlayerAttack - totalEnemyDefense;
                if (damageToEnemy < 0) damageToEnemy = 0;

                if (damageToEnemy > 0)
                {
                    enemyHp -= damageToEnemy;
                    if (enemyHp < 0) enemyHp = 0;
                    Console.WriteLine($"Du triffst den Schatten für {damageToEnemy} Schaden.");
                }
                else
                {
                    Console.WriteLine("Dein Angriff prallt an der Dunkelheit ab.");
                }

                if (enemyHp <= 0)
                {
                    Console.WriteLine("\nDer Schatten beginnt zu zerfallen...");
                    break;
                }

                Console.WriteLine();

                // --- Schatten greift an ---
                int totalEnemyAttack = enemyAttack;
                int totalPlayerDefense = baseDefense + bonusDefense + defensePoints;

                int damageToPlayer = totalEnemyAttack - totalPlayerDefense;
                if (damageToPlayer < 0) damageToPlayer = 0;

                if (damageToPlayer > 0)
                {
                    playerHp -= damageToPlayer;
                    if (playerHp < 0) playerHp = 0;
                    Console.WriteLine($"Der Schatten trifft dich für {damageToPlayer} Schaden.");
                }
                else
                {
                    Console.WriteLine("Du parierst den Angriff des Schattens.");
                }

                Console.WriteLine();
                Console.WriteLine("Drücke eine Taste für die nächste Runde...");
                Console.ReadKey(true);
                Console.Clear();

                round++;
            }

            if (playerHp > 0)
            {
                Console.WriteLine("Du hast deinen Schatten besiegt.");
                return true;
            }

            Console.WriteLine("Du wurdest von deinem Schatten überwältigt.");
            return false;
        }

        /// <summary>
        /// Einmal pro Kampf kann der Spieler eine reale Aufgabe nennen
        /// und +2 permanente Punkte auf Angriff / Verteidigung verteilen.
        /// </summary>
        private static void HandleRealWorldTask(
            ref int bonusAttack,
            ref int bonusDefense,
            ref bool bonusUsed)
        {
            Console.Clear();
            Console.WriteLine("=== Reale Aufgabe ===");
            Console.WriteLine("Welche reale Aufgabe hast du heute erfüllt?");
            Console.WriteLine("(z.B. Lernen, Training, schwieriges Gespräch, Haushalt, usw.)");
            Console.Write("> ");
            string? quest = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Die Götter spüren deine Tat in der echten Welt.");
            Console.WriteLine("Du erhältst 2 permanente Bonuspunkte für diesen Kampf.");
            Console.WriteLine();
            Console.WriteLine("Wie möchtest du sie verteilen?");
            Console.WriteLine("1) +2 Angriff");
            Console.WriteLine("2) +2 Verteidigung");
            Console.WriteLine("3) +1 Angriff, +1 Verteidigung");
            Console.Write("> ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                bonusAttack += 2;
                Console.WriteLine("\nDu fühlst, wie deine Schlagkraft wächst. (+2 Angriff)");
            }
            else if (choice == "2")
            {
                bonusDefense += 2;
                Console.WriteLine("\nDu stehst fester als zuvor. (+2 Verteidigung)");
            }
            else
            {
                bonusAttack += 1;
                bonusDefense += 1;
                Console.WriteLine("\nDu findest Balance zwischen Angriff und Schutz. (+1/+1)");
            }

            bonusUsed = true;
        }
    }
}
