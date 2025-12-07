namespace PathOfCalling.Domain
{
    public static class PlayerArchetypeSetup
    {
        // 10 Startpunkte pro Archetyp
        public static void ApplyBaseStats(Player player)
        {
            switch (player.ArchetypeId)
            {
                case "Knight":
                    player.Stats[StatType.Strength]    = 2;
                    player.Stats[StatType.Discipline] = 3;
                    player.Stats[StatType.Courage]    = 3;
                    player.Stats[StatType.Wisdom]     = 1;
                    player.Stats[StatType.Creativity] = 1;
                    break;

                case "Samurai":
                    player.Stats[StatType.Strength]    = 2;
                    player.Stats[StatType.Discipline] = 4;
                    player.Stats[StatType.Courage]    = 1;
                    player.Stats[StatType.Wisdom]     = 2;
                    player.Stats[StatType.Creativity] = 1;
                    break;

                case "Viking":
                    player.Stats[StatType.Strength]    = 4;
                    player.Stats[StatType.Discipline] = 1;
                    player.Stats[StatType.Courage]    = 3;
                    player.Stats[StatType.Wisdom]     = 1;
                    player.Stats[StatType.Creativity] = 1;
                    break;

                case "Bard":
                    player.Stats[StatType.Strength]    = 1;
                    player.Stats[StatType.Discipline] = 1;
                    player.Stats[StatType.Courage]    = 2;
                    player.Stats[StatType.Wisdom]     = 2;
                    player.Stats[StatType.Creativity] = 4;
                    break;

                default:
                    // Fallback-Verteilung
                    player.Stats[StatType.Strength]    = 2;
                    player.Stats[StatType.Discipline] = 2;
                    player.Stats[StatType.Courage]    = 2;
                    player.Stats[StatType.Wisdom]     = 2;
                    player.Stats[StatType.Creativity] = 2;
                    break;
            }
        }
    }
}
