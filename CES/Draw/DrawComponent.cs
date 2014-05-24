using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentEntitySystem.CES.Physics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK;

namespace ComponentEntitySystem.CES.Draw
{
    class SquareDrawComponent : Component
    {
        public static string Name { get { return DrawSystem.Name; } }

        private float _width;
        private float _height;

        public SquareDrawComponent(float Width, float Height)
        {
            _width = Width;
            _height = Height;
        }

        /// <summary>
        /// Draws the component
        /// </summary>
        public  override void Execute()
        {
            // Get the position and rotation data from the physics component
            PhysicsComponent PhysicsComponent = (PhysicsComponent)EntityManager.GetEntityById(ParentId).GetComponentByName(PhysicsSystem.Name);
            Microsoft.Xna.Framework.Vector2 Position = PhysicsComponent.Body.Position;
            float Rotation = PhysicsComponent.Body.Rotation;

            // Create a transformation matrix based on the position and rotation
            Matrix4 Translate = Matrix4.CreateTranslation(Position.X, Position.Y,0);
            Matrix4 Rotate = Matrix4.CreateRotationZ(Rotation);
            Matrix4 Transform = Translate * Rotate;

            // Push the Matrix stack and add a new matrix
            GL.PushMatrix();
            GL.MultMatrix(ref Transform);

            // Set draw parameters
            GL.PolygonMode(MaterialFace.Front,PolygonMode.Fill);
            GL.Color3(Color.Chocolate);
            GL.Begin(BeginMode.Quads);

            // Draw the shape
            getCorners().ForEach(corner => GL.Vertex2(corner));

            // Finish the draw and pop the matrix stack
            GL.PopMatrix();
        }

        private List<Vector2> getCorners()
        {
            List<Vector2> ReturnObject = new List<Vector2>();

            float HalfWidth = _width / 2;
            float HalfHeight = _height / 2;

            ReturnObject.Add(new Vector2(HalfWidth, HalfHeight));
            ReturnObject.Add(new Vector2(HalfWidth, -HalfHeight));
            ReturnObject.Add(new Vector2(-HalfWidth, -HalfHeight));
            ReturnObject.Add(new Vector2(-HalfWidth, HalfHeight));

            return ReturnObject;
        }
    }
}
