using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ExecutionException : Exception
    {
        private string message;

        public ExecutionException(string message)
        {
            this.message = message;
        }

        public override string Message => message;
    }
}
