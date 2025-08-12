namespace EternalQuest
{
    // Simple goal that can be completed once
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                return Points;
            }
            return 0; // Already complete, no points
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{Name}|{Description}|{Points}|{IsComplete}";
        }
    }
}