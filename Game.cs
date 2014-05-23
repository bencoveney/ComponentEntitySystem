using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using FarseerPhysics.Dynamics;

using ComponentEntitySystem.CES;
using ComponentEntitySystem.CES.Physics;

namespace ComponentEntitySystem
{
    class Game : GameWindow
    {
        private static World _world = new World(new Microsoft.Xna.Framework.Vector2(0f, 9.82f));
        public static World World { get { return _world; } }

        public PhysicsSystem _physicsSystem;

        public Game(int width, int height, GraphicsMode graphicsMode, GameWindowFlags windowFlags, DisplayDevice device, int major, int minor, GraphicsContextFlags contextFlags) 
            : base(width, height, graphicsMode, "ComponentEntitySystem", windowFlags, device, major, minor, contextFlags)
        {
            // Update at 60fps
            this.Run(60);
        }

        /// <summary>
        /// Handles initialisation
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.VSync = VSyncMode.On;

            _physicsSystem = new PhysicsSystem();

            base.OnLoad(e);
        }

        /// <summary>
        /// Handles changes to the viewport size
        /// </summary>
        /// <param name="e">Args</param>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
            base.OnResize(e);
        }

        /// <summary>
        /// Main update method, called 60 times each second
        /// </summary>
        /// <param name="e"></param>
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
        /// <param name="e"></param>
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
                (this.Height / 2),
                -(this.Height / 2),
                0.0,
                4.0);

            // Swap Buffers
            this.SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}
