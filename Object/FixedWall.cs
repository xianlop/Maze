using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Object
{
    internal class FixedWall : Objects
    {
        Abstract.Position Position;
        public Abstract.IntervalBlockType IntervalBlockType;

        public FixedWall(int x, int y, Abstract.IntervalBlockType intervalBlockType)
        {
            Position = new Abstract.Position(x, y);
            IntervalBlockType = intervalBlockType;
        }
        public override void Draw(bool WhetherToSolution)
        {
            Console.ForegroundColor = IntervalBlockType == Abstract.IntervalBlockType.Wall ? ConsoleColor.Gray :
                                      WhetherToSolution ?
                                      IntervalBlockType == Abstract.IntervalBlockType.Entrance
                                   || IntervalBlockType == Abstract.IntervalBlockType.Export ? ConsoleColor.DarkGreen :
                                      ConsoleColor.White : ConsoleColor.Black;
            Console.SetCursorPosition(Position.X * 2, Position.Y);
            Console.Write("■");
        }
    }
}
