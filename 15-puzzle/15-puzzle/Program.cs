using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _15_puzzle
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] numberedSquare = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
           // Game game;
           
           // try
            //{
                   
                //Range.Check(numberedSquare);
                //game = new Game(numberedSquare);
                //Console.WriteLine("Исходное поле");
                //Console.WriteLine(game);
                //try
            //    {
            //        game.Shift(12);
            //    }
            //    catch (ArgumentException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    Console.WriteLine(game);
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //try
            //{
            //    Console.WriteLine(Game.FromCSV("input.csv"));
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            Game3 game = new Game3(numberedSquare);
            game.Shift(15);
            game.Randomize();
            Console.WriteLine(game.GetAllHistory().Count);
            var c = new UI(game);
            c.Output();
            c.Input();
        }
     }
}
