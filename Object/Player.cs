using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Object
{
    public enum E_Dir
    {
        up,
        down,
        left,
        right,
        inSitu
    }
    internal class Player : Objects
    {
        public Abstract.Position Position;
        public Abstract.E_IntervalBlockType E_IntervalBlockType;
        public Object.Bricks[,] Bricks;
        public E_Dir e_Dir;
        public Player(int x, int y, Abstract.E_IntervalBlockType e_IntervalBlockType)
        {
            Position = new Abstract.Position(x, y);
            E_IntervalBlockType = e_IntervalBlockType;
            e_Dir = E_Dir.inSitu;
        }
        public Object.Bricks[,] bricks { set => Bricks = value; }
        public void UpDate()
        {
            if (DetectionType(Position.X, Position.Y))
            {
                Console.Clear();
                Console.SetWindowSize(100, 35);
                Console.SetBufferSize(100, 35);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Abstract.Generate.High / 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(@"
      ___           ___           ___           ___           ___           ___           ___     
     /  /\         /__/\         /  /\         /  /\         /  /\         /  /\         /  /\    
    /  /:/_        \  \:\       /  /:/        /  /:/        /  /:/_       /  /:/_       /  /:/_   
   /  /:/ /\        \  \:\     /  /:/        /  /:/        /  /:/ /\     /  /:/ /\     /  /:/ /\  
  /  /:/ /::\   ___  \  \:\   /  /:/  ___   /  /:/  ___   /  /:/ /:/_   /  /:/ /::\   /  /:/ /::\ 
 /__/:/ /:/\:\ /__/\  \__\:\ /__/:/  /  /\ /__/:/  /  /\ /__/:/ /:/ /\ /__/:/ /:/\:\ /__/:/ /:/\:\
 \  \:\/:/~/:/ \  \:\ /  /:/ \  \:\ /  /:/ \  \:\ /  /:/ \  \:\/:/ /:/ \  \:\/:/~/:/ \  \:\/:/~/:/
  \  \::/ /:/   \  \:\  /:/   \  \:\  /:/   \  \:\  /:/   \  \::/ /:/   \  \::/ /:/   \  \::/ /:/ 
   \__\/ /:/     \  \:\/:/     \  \:\/:/     \  \:\/:/     \  \:\/:/     \__\/ /:/     \__\/ /:/  
     /__/:/       \  \::/       \  \::/       \  \::/       \  \::/        /__/:/        /__/:/   
     \__\/         \__\/         \__\/         \__\/         \__\/         \__\/         \__\/    ");
                Console.ReadKey(true);
                Console.Clear();
                Environment.Exit(0);
            }
            switch (e_Dir)
            {
                case E_Dir.up:
                    if (Position.Y > 0 && DetectionType(Position.X, Position.Y, e_Dir))
                    {
                        Clear();
                        Position.Y--;
                    }
                    else
                    {
                        e_Dir = E_Dir.inSitu;
                    }
                    break;
                case E_Dir.down:
                    if (Position.Y < Abstract.Generate.High - 3 && DetectionType(Position.X, Position.Y, e_Dir))
                    {
                        Clear();
                        Position.Y++;
                    }
                    else
                    {
                        e_Dir = E_Dir.inSitu;
                    }
                    break;
                case E_Dir.left:
                    if (Position.X > 0 && DetectionType(Position.X, Position.Y, e_Dir))
                    {
                        Clear();
                        Position.X--;
                    }
                    else
                    {
                        e_Dir = E_Dir.inSitu;
                    }
                    break;
                case E_Dir.right:
                    if (Position.X < Abstract.Generate.Width - 3 && DetectionType(Position.X, Position.Y, e_Dir))
                    {
                        Clear();
                        Position.X++;
                    }
                    else
                    {
                        e_Dir = E_Dir.inSitu;
                    }
                    break;
                case E_Dir.inSitu:
                    break;
                default:
                    break;
            }
        }
        public void Clear()
        {
            Console.SetCursorPosition((Position.X + 1) * 2, Position.Y + 1);
            Console.Write("  ");
        }
        public void SetMoveE_Dir(E_Dir Dir)
        {
            e_Dir = Dir;
        }
        /// <summary>
        /// 检测前方是否有路
        /// </summary>
        /// <param name="Object1"></param>
        /// <param name="Object2"></param>
        /// <returns></returns>
        public bool DetectionType(int x, int y, Object.E_Dir e_Dir)
        {
            bool IsThereAWay = false;
            switch (e_Dir)
            {
                case Object.E_Dir.up:
                    IsThereAWay = Bricks[x, y - 1].E_IntervalBlockType == Abstract.E_IntervalBlockType.Road
                               || Bricks[x, y - 1].E_IntervalBlockType == Abstract.E_IntervalBlockType.Untie ? true : false;
                    break;
                case Object.E_Dir.down:
                    IsThereAWay = Bricks[x, y + 1].E_IntervalBlockType == Abstract.E_IntervalBlockType.Road
                               || Bricks[x, y + 1].E_IntervalBlockType == Abstract.E_IntervalBlockType.Untie ? true : false;
                    break;
                case Object.E_Dir.left:
                    IsThereAWay = Bricks[x - 1, y].E_IntervalBlockType == Abstract.E_IntervalBlockType.Road
                               || Bricks[x - 1, y].E_IntervalBlockType == Abstract.E_IntervalBlockType.Untie ? true : false;
                    break;
                case Object.E_Dir.right:
                    IsThereAWay = Bricks[x + 1, y].E_IntervalBlockType == Abstract.E_IntervalBlockType.Road
                               || Bricks[x + 1, y].E_IntervalBlockType == Abstract.E_IntervalBlockType.Untie ? true : false;
                    break;
                default:
                    break;
            }
            return IsThereAWay;
        }
        /// <summary>
        /// 判断是否到终点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool DetectionType(int x, int y)
        {
            return x == Abstract.Generate.Width - 3 && y == Abstract.Generate.High - 3 ? true : false;
        }
        public override void Draw(bool WhetherToSolution)
        {
            if (!WhetherToSolution)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition((Position.X + 1) * 2, Position.Y + 1);
                Console.Write("■");
            }
        }
    }
}
