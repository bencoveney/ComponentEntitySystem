// <copyright file="SquareDrawComponent.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem.CES.Draw
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using ComponentEntitySystem.CES.Physics;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    /// <summary>
    /// Defines a Square draw component used by the Draw system
    /// </summary>
    public class SquareDrawComponent : IComponent
    {
        /// <summary>
        /// The width of the square
        /// </summary>
        private float width;

        /// <summary>
        ///  The height of the square
        /// </summary>
        private float height;

        /// <summary>
        /// Initializes a new instance of the SquareDrawComponent class
        /// </summary>
        /// <param name="width">The width of the square</param>
        /// <param name="height">The height of the square</param>
        public SquareDrawComponent(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets the component's name
        /// </summary>
        public string Name
        {
            get
            {
                return "Draw";
            }
        }

        /// <summary>
        /// Gets or sets the id of the parent entity
        /// </summary>
        public int ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// Draws the component
        /// </summary>
        public void Execute()
        {
            // Get the position and rotation data from the physics component
            PhysicsComponent physicsComponent = (PhysicsComponent)EntityManager.GetEntityById(this.ParentId).GetComponentByName("Physics");
            Microsoft.Xna.Framework.Vector2 position = physicsComponent.Body.Position;
            float rotation = physicsComponent.Body.Rotation;

            // Create a transformation matrix based on the position and rotation
            Matrix4 translate = Matrix4.CreateTranslation(position.X, position.Y, 0);
            Matrix4 rotate = Matrix4.CreateRotationZ(rotation);
            Matrix4 transform = translate * rotate;

            // Push the Matrix stack and add a new matrix
            GL.PushMatrix();
            GL.MultMatrix(ref transform);

            // Set draw parameters
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.Color3(Color.Chocolate);
            GL.Begin(BeginMode.Quads);

            // Draw the shape
            this.GetCorners().ForEach(corner => GL.Vertex2(corner));

            // Finish the draw and pop the matrix stack
            GL.PopMatrix();
        }

        /// <summary>
        /// Returns the corners of the square relative to it's center
        /// </summary>
        /// <returns>A list of corners</returns>
        private List<Vector2> GetCorners()
        {
            List<Vector2> returnObject = new List<Vector2>();

            float halfWidth = this.width / 2;
            float halfHeight = this.height / 2;

            returnObject.Add(new Vector2(halfWidth, halfHeight));
            returnObject.Add(new Vector2(halfWidth, -halfHeight));
            returnObject.Add(new Vector2(-halfWidth, -halfHeight));
            returnObject.Add(new Vector2(-halfWidth, halfHeight));

            return returnObject;
        }
    }
}
