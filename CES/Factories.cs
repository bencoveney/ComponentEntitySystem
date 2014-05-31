// <copyright file="Factories.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem.CES
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ComponentEntitySystem.CES.Draw;
    using ComponentEntitySystem.CES.Physics;
    using FarseerPhysics.Collision.Shapes;
    using FarseerPhysics.Common;

    /// <summary>
    /// Provides a method of quickly creating pre-made bundles of entities and components
    /// </summary>
    public class Factories
    {
        /// <summary>
        /// Creates an Square entity with physics and draw components
        /// </summary>
        /// <param name="width">The square's width</param>
        /// <param name="height">The square's height</param>
        /// <param name="positionX">The square's position in the X axis</param>
        /// <param name="positionY">The square's position in the y axis</param>
        /// <param name="rotation">The square's rotation</param>
        /// <param name="isStatic">Is the object static or can it move?</param>
        /// <returns>a square entity</returns>
        public static Entity CreateSquare(float width, float height, float positionX, float positionY, float rotation, bool isStatic)
        {
            // Create the entity
            Entity returnObject = new Entity();

            // Create the physics component
            PhysicsComponent physics = new PhysicsComponent(0, 0, 0, false);

            // Create the physics component's shape and assign it
            Vertices vertices = new Vertices();
            float halfWidth = width / 2;
            float halfHeight = height / 2;
            vertices.Add(new Microsoft.Xna.Framework.Vector2(halfWidth, halfHeight));
            vertices.Add(new Microsoft.Xna.Framework.Vector2(halfWidth, -halfHeight));
            vertices.Add(new Microsoft.Xna.Framework.Vector2(-halfWidth, -halfHeight));
            vertices.Add(new Microsoft.Xna.Framework.Vector2(-halfWidth, halfHeight));
            PolygonShape polygonShape = new PolygonShape(vertices, 1);
            physics.AttachShape(polygonShape);

            // Assign the physics component to the entity
            returnObject.AddComponent(physics);

            // Create the draw component and assign it
            SquareDrawComponent draw = new SquareDrawComponent(100, 50);
            returnObject.AddComponent(draw);

            return returnObject;
        }
    }
}
