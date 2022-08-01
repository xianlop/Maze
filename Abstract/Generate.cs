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
        Map Map;
        Operate.Prims Prim;
        public Generate()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Width * 2,High);
            Console.SetBufferSize(Width * 2, High);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(936);
            
            Map = new Map();
            Prim = new Operate.Prims(Map);
        }
        public void Start()
        {
            bool WhetherToSolution = false;//是否生成解决方案
            Prim.Run();//生成迷宫
            Map.GenerateWall();//生成墙壁
            Map.SetTheOpening();//设置开口
            Map.Draw(WhetherToSolution);//绘制迷宫
        }
    }
}
