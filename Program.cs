// <copyright file="Program.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FarseerPhysics.Dynamics;

    using OpenTK;
    using OpenTK.Graphics;

    /// <summary>
    /// Launches the main game object
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The program's launching point
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        public static void Main(string[] args)
        {
            Game game = new Game(1920, 1080, GraphicsMode.Default, GameWindowFlags.Default, DisplayDevice.Default, 3, 0, GraphicsContextFlags.Default);
        }
    }
}
