using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _15_puzzle
{
    class Game : IPlayable
    {
        private int[,] side;
        public int SizeOfSide { get; protected set; }
        protected Dictionary<int, Coordinate> coor;
        public Game(params int[] numberedSquare)
        {
            coor = new Dictionary<int,Coordinate>();
            SizeOfSide = Convert.ToInt32(Math.Sqrt(numberedSquare.Count()));
            side = new int[SizeOfSide, SizeOfSide];
            for (int i = 0; i < SizeOfSide; i++)
            {
                for (int j = 0; j < SizeOfSide; j++)
                {
                    int value = numberedSquare[i * SizeOfSide + j];
                    side[i,j] = value;
                    coor.Add(value, new Coordinate(i, j));
                }
            }
        }
        public int this[int x, int y]
        {
            get
            {
                return side[x,y];
            }
            protected set
            {
                side[x,y] = value;
            }
        }
        public Coordinate GetLocation(int value)
        {       
           return coor[value];   
        }
        public virtual void Shift(int value)
        {
           
            if (coor[value] - coor[0] == 1)
            {
                Coordinate Temporal = coor[0];
                this[coor[0].X , coor[0].Y] = value;
                this[coor[value].X , coor[value].Y] = 0;
                coor[0] = coor[value];
                coor[value] = Temporal;
            }
            else throw new ArgumentException("Невозможно передвинуть фишку");
        }
        public static Game FromCSV(string file)
        {
            string[] data = File.ReadAllLines(file);
            List<int> convertedData = new List<int>();
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data[i].Split(';').Count(); j++)
                {
                    convertedData.Add(Convert.ToInt32(data[i].Split(';')[j]));
                }
            }
            Range.Check(convertedData.ToArray<int>());
            return new Game(convertedData.ToArray<int>());
        }
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < SizeOfSide; i++)
            {
                for (int j = 0; j < SizeOfSide; j++)
                {
                    output += this[i, j] + "   ";
                }
                output += "\n";
            }
   
            return output;
        }
        public virtual void Randomize()
        {
            var field = SizeOfSide * SizeOfSide;
            var rand = new Random();
            for (int i = 0; i < field; i++)
            {
                var possibility = CheckPossibilityOfMoving();
                Shift(possibility[rand.Next(possibility.Count - 1)]);
            }
            
        }
        protected List<int> CheckPossibilityOfMoving()
        {
            var possibility = new List<int>();
            if (GetLocation(0).X != 0)
                possibility.Add(this[GetLocation(0).X - 1, GetLocation(0).Y]);
            if (GetLocation(0).Y != 0)
                possibility.Add(this[GetLocation(0).X, GetLocation(0).Y - 1]);
            if (GetLocation(0).X != SizeOfSide - 1)
                possibility.Add(this[GetLocation(0).X + 1, GetLocation(0).Y]);
            if (GetLocation(0).Y != SizeOfSide - 1)
                possibility.Add(this[GetLocation(0).X, GetLocation(0).Y + 1]);
            return possibility;
        }
        public bool IsFinished()
        {
            for (int i = 0; i < SizeOfSide; i++)
            {
                for (int j = 0; j < SizeOfSide; j++)
                {
                    if (i == SizeOfSide - 1 && j == SizeOfSide - 1 && this[i, j] == 0)
                        continue;
                    else if (this[i, j] == i * SizeOfSide + j + 1 && (i != SizeOfSide - 1 || j != SizeOfSide - 1))
                        continue;
                    else return false;
                }
            }
            return true;
        }
    }
}
