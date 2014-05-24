using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentEntitySystem.CES.Physics;
using FarseerPhysics.Common;
using FarseerPhysics.Collision.Shapes;
using ComponentEntitySystem.CES.Draw;

namespace ComponentEntitySystem.CES
{
    class Factories
    {
        public static Entity CreateSquare(float Width, float Height, float PositionX, float PositionY, float rotation, bool IsStatic)
        {
            // Create the entity
            Entity ReturnObject = new Entity();

            // Create the physics component
            PhysicsComponent physics = new PhysicsComponent(0,0,0,false);

            // Create the physics component's shape and assign it
            Vertices vertices = new Vertices();
            float halfWidth = Width / 2;
            float halfHeight = Height / 2;
            vertices.Add(new Microsoft.Xna.Framework.Vector2(halfWidth, halfHeight));
            vertices.Add(new Microsoft.Xna.Framework.Vector2(halfWidth, -halfHeight));
            vertices.Add(new Microsoft.Xna.Framework.Vector2(-halfWidth, -halfHeight));
            vertices.Add(new Microsoft.Xna.Framework.Vector2(-halfWidth, halfHeight));
            PolygonShape polygonShape = new PolygonShape(vertices, 1);
            physics.AttachShape(polygonShape);

            // Assign the physics component to the entity
            ReturnObject.AddComponent(physics);

            // Create the draw component and assign it
            SquareDrawComponent Draw = new SquareDrawComponent(100, 50);
            ReturnObject.AddComponent(Draw);

            return ReturnObject;
        }
    }
}
