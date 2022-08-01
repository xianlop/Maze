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
        public Abstract.E_IntervalBlockType E_IntervalBlockType;
        public Bricks[] AdjacentBlock;
        public Bricks(int x, int y, Abstract.E_IntervalBlockType E_IntervalBlockType)
        {
            AdjacentBlock = new Bricks[4];
            Position = new Abstract.Position(x, y);
            E_IntervalBlockType = E_IntervalBlockType;
        }
        public void AddAdjacentBlocks(Bricks[,] bricks)
        {
            if (E_IntervalBlockType == Abstract.E_IntervalBlockType.GridPoint)
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
            if (!WhetherToSolution && E_IntervalBlockType == Abstract.E_IntervalBlockType.Wall)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition((Position.X + 1) * 2, Position.Y + 1);
                Console.Write("■");
            }
            else if(WhetherToSolution)
            {
                Console.ForegroundColor = E_IntervalBlockType == Abstract.E_IntervalBlockType.Wall ? ConsoleColor.Gray :
                                          E_IntervalBlockType == Abstract.E_IntervalBlockType.Road ? ConsoleColor.Black :
                                          WhetherToSolution ?
                                          E_IntervalBlockType == Abstract.E_IntervalBlockType.Untie ? ConsoleColor.DarkGreen : ConsoleColor.White : ConsoleColor.Black;
                Console.SetCursorPosition((Position.X + 1) * 2, Position.Y + 1);
                Console.Write("■");
            }
        }
    }
}
