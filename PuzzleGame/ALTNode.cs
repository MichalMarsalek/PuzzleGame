﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public abstract class ALTNode
    {
        public abstract ASTNode ToAST();
        public LexToken Token { get; protected set; }
    }
}
