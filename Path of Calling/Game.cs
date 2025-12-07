using System;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    public class Game
    {
        private Player _player;
        private bool _running = true;

        public void Run()
        {
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
            Console.WriteLine("2) Spiel laden (später)");
            Console.WriteLine("3) Beenden");
            Console.Write("\nAuswahl: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    Console.WriteLine("Ladefunktion wird in einem späteren Projekttag implementiert.");
                    Pause();
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

            _player = new Player
            {
                Name = name,
                Level = 1
            };

            // Tag 3: Persönlichkeitstest führt zur Archetyp-Bestimmung
            PersonalityTestService.RunPersonalityTestAndAssignArchetype(_player);

            // Kurze Zusammenfassung
            var arch = ArchetypeRepository.GetById(_player.ArchetypeId);
            Console.Clear();
            Console.WriteLine("=== Deine Startkonfiguration ===\n");
            Console.WriteLine($"Name:      {_player.Name}");
            Console.WriteLine($"Archetyp:  {arch?.Name ?? _player.ArchetypeId}");
            Console.WriteLine($"Gott:      {arch?.GodName}");
            Console.WriteLine($"Temperament: {arch?.Temperament}");
            Console.WriteLine("\nStartwerte:");
            foreach (var kv in _player.Stats)
            {
                Console.WriteLine($"- {kv.Key}: {kv.Value}");
            }

            Console.WriteLine("\nAb den nächsten Projekttagen folgen:");
            Console.WriteLine("- Level 1–5 mit je 4 Fragen");
            Console.WriteLine("- Kämpfe gegen schwache Gegner");
            Console.WriteLine("- Finale Prüfung gegen deinen Gott");
            Pause();

            // Hier später: InGame-Menü / Story / Kämpfe
            // ShowInGameMenu();
        }

        private void Pause()
        {
            Console.WriteLine("\nDrücke eine Taste, um fortzufahren...");
            Console.ReadKey(true);
        }
    }
}
