namespace EternalQuest
{
    // Eternal goals never complete; points earned every time
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            return Points;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal|{Name}|{Description}|{Points}";
        }
    }
}