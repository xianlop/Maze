using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Object
{
    internal class Bricks : Objects
    {
        public Abstract.Position Position;
        public Abstract.IntervalBlockType IntervalBlockType;
        public Bricks[] AdjacentBlock;
        public Bricks(int x, int y, Abstract.IntervalBlockType intervalBlockType)
        {
            AdjacentBlock = new Bricks[4];
            Position = new Abstract.Position(x, y);
            IntervalBlockType = intervalBlockType;
        }
        public void AddAdjacentBlocks(Bricks[,] bricks)
        {
            if (IntervalBlockType == Abstract.IntervalBlockType.GridPoint)
            {
                int x = Position.X;
                int y = Position.Y;
                if (x != 0)
                {
                    AdjacentBlock[0] = bricks[x - 2, y];
                }
                if (x != Abstract.Generate.Width - 3)
                {
                    AdjacentBlock[1] = bricks[x + 2, y];
                }
                if (y != 0)
                {
                    AdjacentBlock[2] = bricks[x, y - 2];
                }
                if (y != Abstract.Generate.High - 3)
                {
                    AdjacentBlock[3] = bricks[x, y + 2];
                }
            }
        }
        public override void Draw(bool WhetherToSolution)
        {
            Console.ForegroundColor = IntervalBlockType == Abstract.IntervalBlockType.Wall ? ConsoleColor.Gray :
                                      IntervalBlockType == Abstract.IntervalBlockType.GridPoint ? ConsoleColor.Green :
                                      IntervalBlockType == Abstract.IntervalBlockType.Road ? ConsoleColor.Black : 
                                      WhetherToSolution ?  
                                      IntervalBlockType == Abstract.IntervalBlockType.Untie ? ConsoleColor.DarkGreen : ConsoleColor.White : ConsoleColor.Black;
            Console.SetCursorPosition((Position.X + 1) * 2, Position.Y + 1);
            Console.Write("■");
        }
    }
}
