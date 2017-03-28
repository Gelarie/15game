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
            string output = "";
            for (int i = 0; i < Game.SizeOfSide; i++)
            {
                for (int j = 0; j < Game.SizeOfSide; j++)
                {
                    output += Game[i, j] + "   ";
                }
                output += "\n";
            }
            Console.WriteLine(output);
            Console.WriteLine(Game);
        }
        public void StartGame()
        {
            while (true)
            {
                Output();
                Input();
            }
        }
    }
}