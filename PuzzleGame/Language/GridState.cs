using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class GridState
    {
        public List<Dot> Dots { get; private set; }
        public Dictionary<Colors, Line> Lines { get; private set; }
        public Dictionary<Colors, Line> Polygons { get; private set; }
        public List<bool> Rules { get; private set; }

        public GridState(Grid2 grid)
        {
            Dots = grid.Dots;
            Lines = grid.Lines.Where(i => i != null).ToDictionary(i => i.Color, i => i);
            Polygons = new Dictionary<Colors, Line>();
        }
        public GridState(List<bool> rules)
        {
            Rules = rules;
        }

        //Selection helpers
        private List<bool> PickRules(OrdinalParam a)
        {
            if (a.Order > Rules.Count || Rules.Count == 0)
                return new List<bool>() { false };
            if(a.Last)
                return new List<bool>() { Rules.Last() };
            return new List<bool>() { Rules[a.Order-1] };
        }
        private Dictionary<Colors, Line> PickLines(ColorParam a)
        {
            var result = new Dictionary<Colors, Line>();
            foreach(var color in a.Colors)
            {
                if (Lines.ContainsKey(color))
                    result[color] = Lines[color];
                else
                    result[color] = new Line(color);
            }
            return result;
        }
        private Dictionary<Colors, Line> PickPolygons(ColorParam a)
        {
            var result = new Dictionary<Colors, Line>();
            foreach (var color in a.Colors)
            {
                result[color] = Polygons[color];
            }
            return result;
        }


        //Query functions
        public bool _RuleIs_(CardinalParam a, FullfillnessParam b)
            => (bool)Rules.ToMultival(a).Map(i => i == b.Fullfilled).ReduceIfBool();
        public bool _RuleIs_(OrdinalParam a, FullfillnessParam b)
            => (bool)PickRules(a).ToMultival().Map(i => i == b.Fullfilled).ReduceIfBool();

        public Multival<Number> LengthOf_Line(CardinalParam a)
            => Lines.ToMultival(a).Map(i => new Number(i.Length()));
        public Multival<Number> LengthOf_Line(ColorParam a)
            => PickLines(a).ToMultival().Map(i => new Number(i.Length()));

        public bool UniversalTruth() => true;

    }
}
