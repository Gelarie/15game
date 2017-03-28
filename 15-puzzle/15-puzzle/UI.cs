using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class UI
    {
        public IPlayable Game;
        public UI(IPlayable Game)
        {
            this.Game = Game;
        }
        public void Input()
        {
            int value = Convert.ToInt32(Console.ReadLine());
            Game.Shift(value);
        }
        public void Output()
        {
            Console.WriteLine(Game as Game);
        }
    }
}