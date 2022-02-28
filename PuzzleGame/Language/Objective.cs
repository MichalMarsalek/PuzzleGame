using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Objective
    {
        public List<Node> Rules {get; private set;}

        public Objective(List<Node> rules)
        {
            Rules = rules;
        }
    }
}
