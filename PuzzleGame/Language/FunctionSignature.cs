using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class FunctionSignature
    {
        public List<string> Words { get; private set; }
        public FunctionSignature(string name)
        {
            Words = name.Split(' ').ToList();
        }
        public string MethodName { get => String.Join("", Words.Select(i => i.FirstLetterToUpper())); }

        public static List<List<string>> Functions = Properties.Resources.FunctionNames
            .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
            .Select(i => i.Split(' ').ToList()).ToList();
    }
}
