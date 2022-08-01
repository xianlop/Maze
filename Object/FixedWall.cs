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
        public Abstract.E_IntervalBlockType E_IntervalBlockType;

        public FixedWall(int x, int y, Abstract.E_IntervalBlockType e_IntervalBlockType)
        {
            Position = new Abstract.Position(x, y);
            E_IntervalBlockType = e_IntervalBlockType;
        }
        public override void Draw(bool WhetherToSolution)
        {
            if (E_IntervalBlockType == Abstract.E_IntervalBlockType.Wall)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(Position.X * 2, Position.Y);
                Console.Write("■");
            }
        }
    }
}
