using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;

using FarseerPhysics.Dynamics;

namespace ComponentEntitySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1920, 1080, GraphicsMode.Default, GameWindowFlags.Default, DisplayDevice.Default, 3, 0, GraphicsContextFlags.Default);
        }
    }
}
