using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class CharacterStream
    {
        private Stack<Char> characters;
        private int line = 0;
        private int column = 0;

        public CharacterStream(string text)
        {
            characters = new Stack<char>(text.Reverse());
            prevPosition = new TokenPosition(0, 0);
        }


        private TokenPosition prevPosition;
        public TokenPosition PrevPosition
        {
            get
            {
                TokenPosition temp = prevPosition;
                prevPosition = Position;
                return temp;
            }
        }

        private TokenPosition Position
        {
            get => new TokenPosition(line, column);
        }

        public bool Any() => characters.Any();

        public char Peek() => characters.Peek();

        public char Read()
        {
            char popped = characters.Pop();
            if(popped == '\n')
            {
                line++;
                column = 0;
            }
            else
            {
                column++;
            }
            return popped;
        }

        public void Push(char c)
        {
            characters.Push(c);
            column--;
        }

        public string Remaining { get => String.Join("", characters); }
    }
}
