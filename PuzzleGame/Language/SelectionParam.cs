using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public abstract class SelectionParam : QueryParam
    {
        public abstract bool LinquisticPlural
        {
            get;
        }
        public abstract bool SingleSelection
        {
            get;
        }
    }
}
