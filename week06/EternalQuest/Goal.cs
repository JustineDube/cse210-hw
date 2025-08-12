using System;

namespace EternalQuest
{
    // Abstract base class representing a general goal
    abstract class Goal
    {
        // Private member variables
        private string _name;
        private string _description;
        private int _points;
        private bool _isComplete;

        // Properties for encapsulated access
        public string Name { get => _name; protected set => _name = value; }
        public string Description { get => _description; protected set => _description = value; }
        public int Points { get => _points; protected set => _points = value; }
        public bool IsComplete { get => _isComplete; protected set => _isComplete = value; }

        // Constructor
        protected Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            IsComplete = false;
        }

        // Abstract method to record progress; must be implemented by derived classes
        public abstract int RecordEvent();

        // Virtual method to get display string; can be overridden
        public virtual string GetDetailsString()
        {
            string status = IsComplete ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description})";
        }

        // Abstract method to get string representation for saving
        public abstract string GetStringRepresentation();
    }
}