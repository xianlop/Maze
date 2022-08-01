using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Operate
{
    internal class Prims
    {
        Object.Bricks[] Path;
        Object.Bricks[,] Bricks;
        Random Random;
        int CurrentIndex;

        public Prims(Abstract.Map map)
        {
            Bricks = map.Bricks;
            Random = new Random();
            Path = new Object.Bricks[map.GridPoints];
            CurrentIndex = 0;
            Path[CurrentIndex] = Bricks[0, 0];
            Path[CurrentIndex].IntervalBlockType = Abstract.IntervalBlockType.Road;
        }
        public void Run()
        {
            for (; !IsGridPoint() || CurrentIndex != 0;)
            {
                SelectAdjacentBlocks();
            }
        }
        public void SelectAdjacentBlocks()
        {
            int Index = Random.Next(0, 4);
            if (Path[CurrentIndex].AdjacentBlock[Index] != null && Path[CurrentIndex].AdjacentBlock[Index].IntervalBlockType == Abstract.IntervalBlockType.GridPoint)
            {
                int x = (Path[CurrentIndex].Position.X + Path[CurrentIndex].AdjacentBlock[Index].Position.X) / 2;
                int y = (Path[CurrentIndex].Position.Y + Path[CurrentIndex].AdjacentBlock[Index].Position.Y) / 2;
                CurrentIndex++;
                Path[CurrentIndex] = Path[CurrentIndex - 1].AdjacentBlock[Index];
                Path[CurrentIndex].IntervalBlockType = Abstract.IntervalBlockType.Road;
                Bricks[x, y].IntervalBlockType = Abstract.IntervalBlockType.Road;
                if (Path[CurrentIndex].Position.X == Bricks.GetLength(0) - 1 && Path[CurrentIndex].Position.Y == Bricks.GetLength(1) - 1)
                {
                    GenerateSolution();
                }
            }
            else if (IsGridPoint())
            {
                CurrentIndex--;
            }
        }
        public void GenerateSolution()
        {
            for (int i = 0; i < Path.Length; i++)
            {
                Path[i].IntervalBlockType = Abstract.IntervalBlockType.Untie;
                if (i != 0 && Path[i - 1] != null)
                {
                    int x = (Path[i].Position.X + Path[i - 1].Position.X) / 2;
                    int y = (Path[i].Position.Y + Path[i - 1].Position.Y) / 2;
                    Bricks[x, y].IntervalBlockType = Abstract.IntervalBlockType.Untie;
                }
                if (Path[i].Position.X == Bricks.GetLength(0) - 1 && Path[i].Position.Y == Bricks.GetLength(1) - 1)
                {
                    break;
                }
            }
        }
        public bool IsGridPoint()
        {
            int NotGridPoints = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Path[CurrentIndex].AdjacentBlock[i] == null)
                {
                    NotGridPoints++;
                }
                else if (Path[CurrentIndex].AdjacentBlock[i].IntervalBlockType != Abstract.IntervalBlockType.GridPoint)
                {
                    NotGridPoints++;
                }
                else
                {
                    break;
                }
            }
            return NotGridPoints == 4 ? true : false;
        }

    }
}
