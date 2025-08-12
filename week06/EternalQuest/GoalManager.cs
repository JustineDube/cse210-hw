using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score;
        private int _level = 1;
        private const int _pointsPerLevel = 500;
        private const string _saveFileName = "goals.txt";

        // Add a new goal
        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        // Display all goals with status
        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }

            Console.WriteLine("Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        // Display current score and level
        public void DisplayScore()
        {
            Console.WriteLine($"Score: {_score} | Level: {_level}");
        }

        // Record progress on a selected goal
        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record.");
                return;
            }

            DisplayGoals();
            Console.Write("Enter the number of the goal you completed: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= _goals.Count)
            {
                int pointsEarned = _goals[choice - 1].RecordEvent();
                if (pointsEarned > 0)
                {
                    Console.WriteLine($"You earned {pointsEarned} points!");
                    AddPoints(pointsEarned);
                }
                else
                {
                    Console.WriteLine("No points earned (goal may already be complete).");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        // Add points and handle leveling up
        private void AddPoints(int points)
        {
            _score += points;

            // Level up for every 500 points earned
            while (_score >= _level * _pointsPerLevel)
            {
                _level++;
                Console.WriteLine($"*** Congratulations! You've reached Level {_level}! ***");
            }
        }

        // Create a goal via user input
        public void CreateGoal()
        {
            Console.WriteLine("Select Goal Type to Create:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string input = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();

            Console.Write("Enter points awarded: ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points value, setting to 0.");
                points = 0;
            }

            switch (input)
            {
                case "1":
                    AddGoal(new SimpleGoal(name, description, points));
                    Console.WriteLine("Simple Goal created.");
                    break;

                case "2":
                    AddGoal(new EternalGoal(name, description, points));
                    Console.WriteLine("Eternal Goal created.");
                    break;

                case "3":
                    Console.Write("Enter required completions: ");
                    int req = int.TryParse(Console.ReadLine(), out int r) ? r : 1;

                    Console.Write("Enter bonus points on completion: ");
                    int bonus = int.TryParse(Console.ReadLine(), out int b) ? b : 0;

                    AddGoal(new ChecklistGoal(name, description, points, req, bonus));
                    Console.WriteLine("Checklist Goal created.");
                    break;

                default:
                    Console.WriteLine("Invalid goal type. Goal not created.");
                    break;
            }
        }

        // Save goals and score to file
        public void SaveGoals()
        {
            try
            {
                using StreamWriter writer = new StreamWriter(_saveFileName);
                writer.WriteLine(_score);
                writer.WriteLine(_level);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
                Console.WriteLine("Goals and progress saved successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving goals: {e.Message}");
            }
        }

        // Load goals and score from file
        public void LoadGoals()
        {
            if (!File.Exists(_saveFileName))
            {
                Console.WriteLine("No saved data found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(_saveFileName);
                if (lines.Length < 2)
                {
                    Console.WriteLine("Save file is corrupted or incomplete.");
                    return;
                }

                _score = int.Parse(lines[0]);
                _level = int.Parse(lines[1]);

                _goals.Clear();

                for (int i = 2; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    string type = parts[0];

                    switch (type)
                    {
                        case "SimpleGoal":
                            var simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                            if (bool.Parse(parts[4])) simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;

                        case "EternalGoal":
                            var eternalGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                            _goals.Add(eternalGoal);
                            break;

                        case "ChecklistGoal":
                            var checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                int.Parse(parts[4]), int.Parse(parts[5]));

                            int currentCount = int.Parse(parts[6]);
                            bool isComplete = bool.Parse(parts[7]);

                            // Replay RecordEvent to restore count
                            for (int j = 0; j < currentCount; j++)
                            {
                                checklistGoal.RecordEvent();
                            }

                            // Ensure completeness status is consistent
                            if (isComplete && !checklistGoal.IsComplete)
                            {
                                while (!checklistGoal.IsComplete)
                                    checklistGoal.RecordEvent();
                            }

                            _goals.Add(checklistGoal);
                            break;

                        default:
                            Console.WriteLine($"Unknown goal type '{type}' in save file.");
                            break;
                    }
                }
                Console.WriteLine("Goals and progress loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading goals: {e.Message}");
            }
        }
    }
}