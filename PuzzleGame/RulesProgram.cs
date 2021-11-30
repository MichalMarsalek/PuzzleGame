using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class RulesProgram
    {
        public List<ASTNode> Expressions;

        public static readonly NameDomain DefaultContext = new NameDomain()
        {
            { "[]", new LangList()},
            { "red", new LangColor(Colors.Red)},
            { "blue", new LangColor(Colors.Blue)},
            { "green", new LangColor(Colors.Green)}
        };

        public RulesProgram(string code)
        {
            throw new Exception();/*
            var parser = new RulesLangParser(code);
            Expressions = parser.GetGroups();*/
        }

        public List<LangValue> Run(NameDomain context = null)
        {
            if (context == null)
                context = DefaultContext;
            return Expressions.Select(i => i.Evaluate(context)).ToList();
        }
    }
}
