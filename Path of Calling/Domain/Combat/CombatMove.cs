namespace PathOfCalling.Domain.Combat
{
    public enum MoveType
    {
        Light,
        Heavy,
        Skill,
        Ultimate
    }

    public class CombatMove
    {
        public string Name { get; set; } = "";
        public MoveType Type { get; set; }

        public int AttackPower { get; set; }
        public int DefensePower { get; set; }

        public string Description { get; set; } = "";
    }
}
