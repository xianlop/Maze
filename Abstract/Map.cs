using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Abstract
{
    enum IntervalBlockType
    {
        GridPoint,
        IntervalBlock,
        Road,
        Wall,
        Export,
        Entrance,
        Untie,
    }
    internal class Map : Object.IObjectDraw
    {
        public Object.Bricks[,] Bricks;
        Object.FixedWall[] FixedWall;
        public int GridPoints = 0;

        public Map()
        {
            Bricks = new Object.Bricks[Generate.Width - 2, Generate.High - 2];
            FixedWall = new Object.FixedWall[Generate.Width * 2 + (Generate.High - 2) * 2];

            //初始化固定壁
            int Index = 0, LastIndex = FixedWall.Length - 1;
            for (int i = 0; i < Generate.Width; i++)
            {
                FixedWall[Index++] = new Object.FixedWall(i, 0, IntervalBlockType.Wall);
                FixedWall[LastIndex--] = new Object.FixedWall(i, Generate.High - 1, IntervalBlockType.Wall);
            }
            for (int i = 1; i < Generate.High - 1; i++)
            {
                FixedWall[Index++] = new Object.FixedWall(0, i, IntervalBlockType.Wall);
                FixedWall[LastIndex--] = new Object.FixedWall(Generate.Width - 1, i, IntervalBlockType.Wall);
            }
            for (int i = 1; i < Generate.Width - 3; i += 2)
            {
                for (int j = 1; j < Generate.High - 3; j += 2)
                {
                    Bricks[i, j] = new Object.Bricks(i, j, IntervalBlockType.Wall);
                }
            }
            //初始化网格点
            for (int j = 0; j < Generate.High - 2; j += 2)
            {
                for (int i = 0; i < Generate.Width - 2; i += 2)
                {
                    Bricks[i, j] = new Object.Bricks(i, j, IntervalBlockType.GridPoint);
                    GridPoints++;
                }
            }
            for (int j = 0; j < Generate.High - 2; j += 2)
            {
                for (int i = 0; i < Generate.Width - 2; i += 2)
                {
                    Bricks[i, j].AddAdjacentBlocks(Bricks);
                }
            }
            //初始化间隔块
            for (int j = 0; j < Generate.High - 2; j++)
            {
                for (int i = 0; i < Generate.Width - 2; i++)
                {
                    if (Bricks[i, j] == null)
                    {
                        Bricks[i, j] = new Object.Bricks(i, j, IntervalBlockType.IntervalBlock);
                    }
                }
            }
        }
        public void SetTheOpening()
        {
            FixedWall[1].IntervalBlockType = IntervalBlockType.Entrance;
            FixedWall[FixedWall.Length - Generate.Width + 1].IntervalBlockType = IntervalBlockType.Export;
        }
        public void GenerateWall()
        {
            for (int i = 0; i < Generate.Width - 2; i++)
            {
                for (int j = 0; j < Generate.High - 2; j++)
                {
                    if (Bricks[i, j].IntervalBlockType != IntervalBlockType.Road && Bricks[i, j].IntervalBlockType != IntervalBlockType.Untie)
                    {
                        Bricks[i, j].IntervalBlockType = IntervalBlockType.Wall;
                    }
                }
            }
        }
        public void Draw(bool WhetherToSolution)
        {
            for (int i = 0; i < FixedWall.Length / 2 + 1; i++)
            {
                FixedWall[i].Draw(WhetherToSolution);
                FixedWall[FixedWall.Length - i -1].Draw(WhetherToSolution);
                Thread.Sleep(1);
            }
            for (int i = 0; i < Bricks.GetLength(0) / 2 + 1; i++)
            {
                for (int j = 0; j < Bricks.GetLength(1); j++)
                {
                    if (Bricks[i, j] != null)
                    {
                        Bricks[i, j].Draw(WhetherToSolution);
                        Bricks[Bricks.GetLength(0) - i - 1, Bricks.GetLength(1) - j - 1].Draw(WhetherToSolution);
                        Thread.Sleep(1);
                    }
                }
            }
        }
    }
}
