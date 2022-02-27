using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class CharacterStream
    {
        private Stack<Char> characters;

        public CharacterStream(string text)
        {
            characters = new Stack<char>(text.Reverse());
        }
        public bool Any() => characters.Any();

        public char Peek() => characters.Peek();

        public char Read() => characters.Pop();

        public void Push(char c) => characters.Push(c);

        public string Remaining { get => String.Join("", characters); }
    }
}
