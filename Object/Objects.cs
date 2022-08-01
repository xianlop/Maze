using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Object
{
    internal abstract class Objects : IObjectDraw
    {
        public abstract void Draw(bool WhetherToSolution);
    }
}
