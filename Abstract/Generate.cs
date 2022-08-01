using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maze.Abstract
{
    internal class Generate
    {
        public const int Width = 25;
        public const int High = 25;
        int frameCount = 0;
        bool WhetherToSolution = false;//是否生成解决方案

        Map Map;
        Operate.Prims Prim;
        public Generate()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Width * 2, High);
            Console.SetBufferSize(Width * 2, High);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(936);

            Map = new Map();
            Prim = new Operate.Prims(Map);
        }
        public void Reset()
        {
            Map = new Map();
            Prim = new Operate.Prims(Map);
        }
        public void Start()
        {
            Prim.Run();//生成迷宫
            Map.GenerateWall();//生成墙壁
            Map.SetTheOpening();//设置开口

            Map.Draw(WhetherToSolution);//绘制迷宫

            Play();
        }
        public void Play()
        {
            for (; true;)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            Map.Player.SetMoveE_Dir(Object.E_Dir.up);
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            Map.Player.SetMoveE_Dir(Object.E_Dir.down);
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            Map.Player.SetMoveE_Dir(Object.E_Dir.left);
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            Map.Player.SetMoveE_Dir(Object.E_Dir.right);
                            break;
                        default:
                            break;
                    }
                }
                frameCount++;
                if (frameCount % 6666 == 0)
                {
                    Map.Player.UpDate();
                    Map.Draw(WhetherToSolution);
                    frameCount = 0;
                }
            }
        }
    }
}
