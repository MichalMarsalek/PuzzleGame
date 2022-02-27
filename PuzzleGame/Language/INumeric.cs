using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public interface INumeric
    {
        INumeric Neg();
        INumeric Sub(INumeric a);
        INumeric Add(INumeric a);
        INumeric Mul(INumeric a);
        INumeric Div(INumeric a);
        INumeric Lt(INumeric a);
        INumeric Le(INumeric a);
        INumeric Gt(INumeric a);
        INumeric Ge(INumeric a);
        INumeric Eq(INumeric a);
        INumeric NotEq(INumeric a);
    }
}
