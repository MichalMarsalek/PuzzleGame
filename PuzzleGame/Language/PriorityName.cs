using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class PriorityName
    {
        public int Priority { get; private set; }
        public string Name { get; private set; }
        public PriorityName(string name, int priority)
        {
            Priority = priority;
            Name = name;
        }

        public override string ToString()
        {
            return Name + " (" + Priority.ToString() + ")";
        }
    }
}
