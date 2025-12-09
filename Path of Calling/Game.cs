using System;
using System.Collections.Generic;
using PathOfCalling.Domain;
using PathOfCalling.Domain.Combat;

namespace PathOfCalling
{
    public class Game
    {
        private Player? _player;
        private bool _running = true;

        public void Run()
        {
            // Zentrale Spielschleife: Hauptmenü
            while (_running)
            {
                ShowMainMenu();
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Path of Calling ===\n");
            Console.WriteLine("1) Neues Spiel");
            Console.WriteLine("2) Spiel laden");
            Console.WriteLine("3) Beenden");
            Console.Write("\nAuswahl: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "3":
                    _running = false;
                    Console.WriteLine("Spiel wird beendet. Auf Wiedersehen.");
                    Pause();
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen.");
                    Pause();
                    break;
            }
        }

        private void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("=== Neues Spiel ===\n");

            Console.Write("Gib den Namen deines Charakters ein: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                name = "Wanderer";

            // Player ohne Archetyp anlegen – Archetyp kommt aus den Götter-Prüfungen
            _player = new Player
            {
                Name = name,
                Level = 1
            };

            // Persönlichkeitstest + Level + Schattenkämpfe
            PersonalityTestService.RunTrialsWithLevels(_player);

            // Sicherstellen, dass ein Archetyp gesetzt ist
            if (string.IsNullOrWhiteSpace(_player.ArchetypeId))
            {
                _player.ArchetypeId = "Knight";
                PlayerArchetypeSetup.ApplyBaseStats(_player);
            }

            // Direkt Spielstand speichern
            SaveService.SavePlayer(_player);

            // Zusammenfassung anzeigen und ins In-Game-Menü wechseln
            ShowCharacterSummary();
            ShowInGameMenu();
        }

        private void LoadGame()
        {
            Console.Clear();
            Console.WriteLine("=== Spiel laden ===\n");

            var loaded = SaveService.LoadPlayer();
            if (loaded == null)
            {
                Console.WriteLine("Kein gültiger Spielstand gefunden.");
                Pause();
                return;
            }

            _player = loaded;
            Console.WriteLine($"Spielstand von {_player.Name} (Level {_player.Level}) geladen.");
            Pause();

            ShowCharacterSummary();
            ShowInGameMenu();
        }

        private void ShowInGameMenu()
        {
            if (_player == null)
                return;

            bool inGame = true;

            while (inGame)
            {
                Console.Clear();
                Console.WriteLine("=== Dein Weg im Path of Calling ===\n");
                Console.WriteLine(
                    $"Aktueller Charakter: {_player.Name} " +
                    $"(Level {_player.Level}, Archetyp: {_player.ArchetypeId})\n");

                Console.WriteLine("1) Charakter anzeigen");
                Console.WriteLine("2) Trainingskampf gegen inneren Schatten");
                Console.WriteLine("3) Kampfmoves anzeigen");
                Console.WriteLine("4) Spiel speichern");
                Console.WriteLine("5) Zurück zum Hauptmenü");
                Console.WriteLine("6) Spiel beenden");
                Console.Write("\nAuswahl: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowCharacterSummary();
                        break;
                    case "2":
                        RunTrainingShadowFight();
                        break;
                    case "3":
                        ShowCombatMoves();
                        break;
                    case "4":
                        SaveCurrentGame();
                        break;
                    case "5":
                        inGame = false;
                        break;
                    case "6":
                        inGame = false;
                        _running = false;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        Pause();
                        break;
                }
            }
        }

        private void ShowCharacterSummary()
        {
            if (_player == null)
                return;

            Console.Clear();
            var archetype = ArchetypeRepository.GetById(_player.ArchetypeId);
            var deity     = DeityRepository.GetByArchetype(_player.ArchetypeId);

            Console.WriteLine("=== Charakterübersicht ===\n");
            Console.WriteLine($"Name:        {_player.Name}");
            Console.WriteLine($"Level:       {_player.Level}");
            Console.WriteLine($"Archetyp:    {archetype?.Name ?? _player.ArchetypeId}");
            Console.WriteLine($"Temperament: {archetype?.Temperament}");
            Console.WriteLine($"Patron-Gott: {archetype?.GodName}");
            Console.WriteLine();

            Console.WriteLine("Stats:");
            foreach (var kv in _player.Stats)
            {
                Console.WriteLine($"- {kv.Key}: {kv.Value}");
            }

            if (deity != null)
            {
                Console.WriteLine("\nGöttliche Aspekte:");
                Console.WriteLine($"{deity.Name} – {deity.Title}");
                foreach (var kv in deity.Stats)
                {
                    Console.WriteLine($"- {kv.Key}: {kv.Value}");
                }
            }

            Console.WriteLine();
            Console.WriteLine(
                $"Ultimate freigeschaltet: {_player.UltimateUnlocked} " +
                $"{(string.IsNullOrWhiteSpace(_player.UltimateName) ? "" : $"({_player.UltimateName})")}"
            );

            Pause();
        }

        private void RunTrainingShadowFight()
        {
            if (_player == null)
                return;

            Console.Clear();
            Console.WriteLine("=== Trainingskampf gegen einen inneren Schatten ===\n");

            // Einfach: Level auf 1–5 clampen, dann passenden Minor-Shadow nehmen
            int level = _player.Level;
            if (level < 1) level = 1;
            if (level > 5) level = 5;

            var shadow = ShadowEnemyRepository.GetMinorShadowForLevel(level, _player.ArchetypeId);

            bool won = ShadowCombatService.RunMinorShadowFight(_player, shadow);

            if (won)
            {
                Console.WriteLine("\nDu hast den Trainings-Schatten besiegt und erhältst einen Skill-Punkt.");
                AllocateSimpleSkillPoint(_player);
            }
            else
            {
                Console.WriteLine("\nDer Schatten bleibt bestehen – du kannst jederzeit erneut trainieren.");
            }

            Pause();
        }

        private void AllocateSimpleSkillPoint(Player player)
        {
            Console.WriteLine("\nWähle ein Attribut, das du steigern möchtest:");

            int i = 1;
            var keys = new List<StatType>(player.Stats.Keys);
            foreach (var key in keys)
            {
                Console.WriteLine($"{i}) {key} (aktuell: {player.Stats[key]})");
                i++;
            }

            Console.Write("\nAuswahl (Zahl): ");
            string? choice = Console.ReadLine();

            if (int.TryParse(choice, out int index) &&
                index >= 1 && index <= keys.Count)
            {
                var stat = keys[index - 1];
                player.Stats[stat]++;
                Console.WriteLine($"\n{stat} wurde erhöht. Neuer Wert: {player.Stats[stat]}");
            }
            else
            {
                Console.WriteLine("Keine gültige Auswahl – Punkt verfällt in diesem Trainingskampf.");
            }
        }

        private void ShowCombatMoves()
        {
            if (_player == null)
                return;

            Console.Clear();
            Console.WriteLine("=== Kampfmoves ===\n");

            var moves = ArchetypeCombatRepository.GetMoves(_player.ArchetypeId, _player.UltimateUnlocked);

            if (moves.Count == 0)
            {
                Console.WriteLine("Keine Moves für diesen Archetyp gefunden.");
                Pause();
                return;
            }

            foreach (var move in moves)
            {
                Console.WriteLine($"[{move.Type}] {move.Name} (ATK {move.AttackPower}, DEF {move.DefensePower})");
                Console.WriteLine($"    {move.Description}");
                Console.WriteLine();
            }

            Pause();
        }

        private void SaveCurrentGame()
        {
            if (_player == null)
                return;

            SaveService.SavePlayer(_player);
            Console.WriteLine("Spielstand wurde gespeichert.");
            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nDrücke eine Taste, um fortzufahren...");
            Console.ReadKey(true);
        }
    }
}
