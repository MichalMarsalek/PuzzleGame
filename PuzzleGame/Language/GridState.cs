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

        public GridState(Grid grid)
        {
            Dots = grid.Dots;
            Lines = grid.Lines.Where(i => i != null).ToDictionary(i => i.Color, i => i);
            Polygons = new Dictionary<Colors, Line>();
        }

        //Selection helpers
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
        public Multival<Number> LengthOf_Line(CardinalParam a)
            => Lines.ToMultival(a).Map(i => new Number(i.Length()));
        public Multival<Number> LengthOf_Line(ColorParam a)
            => PickLines(a).ToMultival().Map(i => new Number(i.Length()));


    }
}
