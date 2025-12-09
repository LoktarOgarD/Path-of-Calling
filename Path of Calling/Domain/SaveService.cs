using System;
using System.IO;
using System.Text.Json;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    public static class SaveService
    {
        private static readonly string SaveFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "savegame.json");

        public static void SavePlayer(Player player)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(player, options);
                File.WriteAllText(SaveFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern des Spielstands:");
                Console.WriteLine(ex.Message);
            }
        }

        public static Player? LoadPlayer()
        {
            try
            {
                if (!File.Exists(SaveFilePath))
                    return null;

                string json = File.ReadAllText(SaveFilePath);
                var player = JsonSerializer.Deserialize<Player>(json);

                return player;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden des Spielstands:");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
