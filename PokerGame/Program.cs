﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameHandler _game = new GameHandler();
            _game.Start();
            Console.ReadKey();
        }
    }
}
