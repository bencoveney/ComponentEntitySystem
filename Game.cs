// <copyright file="Game.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ComponentEntitySystem.CES;
    using ComponentEntitySystem.CES.Draw;
    using ComponentEntitySystem.CES.Physics;

    using FarseerPhysics.Dynamics;

    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using OpenTK.Input;

    /// <summary>
    /// The main object managing the game
    /// </summary>
    public class Game : GameWindow
    {
        #region Data Members

        /// <summary>
        /// The physics simulation
        /// </summary>
        private static World world = new World(new Microsoft.Xna.Framework.Vector2(0f, 9.82f));

        /// <summary>
        /// The physics system
        /// </summary>
        private PhysicsSystem physicsSystem;

        /// <summary>
        /// The draw system
        /// </summary>
        private DrawSystem drawSystem;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Game class
        /// </summary>
        /// <param name="width">The width of the game window</param>
        /// <param name="height">The height of the game window</param>
        /// <param name="graphicsMode">The format of graphics operations</param>
        /// <param name="windowFlags">Game window construction options</param>
        /// <param name="device">The display device being used</param>
        /// <param name="major">The major version number of openGL to use</param>
        /// <param name="minor">The minor version number of openGL to use</param>
        /// <param name="contextFlags">Flags that effect the creation of new graphics objects</param>
        public Game(int width, int height, GraphicsMode graphicsMode, GameWindowFlags windowFlags, DisplayDevice device, int major, int minor, GraphicsContextFlags contextFlags) 
            : base(width, height, graphicsMode, "ComponentEntitySystem", windowFlags, device, major, minor, contextFlags)
        {
            // Update at 60fps
            this.Run(60);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Physics Simulation's current world
        /// </summary>
        public static World World
        {
            get
            {
                return world;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles initialization
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnLoad(EventArgs e)
        {
            this.VSync = VSyncMode.On;

            this.physicsSystem = new PhysicsSystem();
            this.drawSystem = new DrawSystem();

            GL.ClearColor(Color4.SkyBlue);

            EntityManager.AddEntity(Factories.CreateSquare(200, 25, 0, 0, 0, true));

            base.OnLoad(e);
        }

        /// <summary>
        /// Handles changes to the viewport size
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
            base.OnResize(e);
        }

        /// <summary>
        /// Main update method, called 60 times each second
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }

            base.OnUpdateFrame(e);
        }

        /// <summary>
        /// Main draw method, called 60 times each second
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // Clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Create a viewpoint
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(
                -(this.Width / 2),
                this.Width / 2,
                this.Height / 2,
                -(this.Height / 2),
                0.0,
                4.0);

            this.drawSystem.Execute();
            
            // Swap Buffers
            this.SwapBuffers();
            base.OnRenderFrame(e);
        }

        #endregion
    }
}
