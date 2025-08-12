namespace EternalQuest
{
    // Checklist goal requires multiple completions, with bonus on finish
    class ChecklistGoal : Goal
    {
        private int _currentCount;
        private int _requiredCount;
        private int _bonusPoints;

        public int CurrentCount { get => _currentCount; private set => _currentCount = value; }
        public int RequiredCount { get => _requiredCount; private set => _requiredCount = value; }
        public int BonusPoints { get => _bonusPoints; private set => _bonusPoints = value; }

        public ChecklistGoal(string name, string description, int points, int requiredCount, int bonusPoints)
            : base(name, description, points)
        {
            RequiredCount = requiredCount;
            BonusPoints = bonusPoints;
            CurrentCount = 0;
        }

        public override int RecordEvent()
        {
            if (IsComplete)
                return 0;

            CurrentCount++;
            int totalPoints = Points;

            if (CurrentCount >= RequiredCount)
            {
                IsComplete = true;
                totalPoints += BonusPoints;
            }

            return totalPoints;
        }

        public override string GetDetailsString()
        {
            string status = IsComplete ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) -- Completed {CurrentCount}/{RequiredCount} times";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{Name}|{Description}|{Points}|{RequiredCount}|{BonusPoints}|{CurrentCount}|{IsComplete}";
        }
    }
}