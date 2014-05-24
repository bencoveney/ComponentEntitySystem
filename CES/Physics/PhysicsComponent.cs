using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;

namespace ComponentEntitySystem.CES.Physics
{
    class PhysicsComponent : Component
    {
        public override string Name { get { return PhysicsSystem.Name; } }

        private Body _body;
        public Body Body { get { return _body; } }

        #region constructors

        /// <summary>
        /// Constructor, creates a basic body in the world with no physical form
        /// </summary>
        /// <param name="Position">Location of the Body in the world</param>
        /// <param name="Rotation">Rotation of the Body</param>
        /// <param name="isStatic">Is the body effected by physics</param>
        public PhysicsComponent(float PositionX, float PositionY, float Rotation, bool isStatic)
        {
            _body = new Body(Game.World, new Microsoft.Xna.Framework.Vector2(PositionX,PositionY), Rotation);
            _body.BodyType = isStatic ? BodyType.Static : BodyType.Dynamic;
        }

        /// <summary>
        /// Constructor, creates a basic body in the world with no physical form
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="Rotation"></param>
        public PhysicsComponent(float PositionX, float PositionY, float Rotation)
            : this(PositionX, PositionY, Rotation, false) { }

        /// <summary>
        /// Constructor, creates a basic body in the world with no physical form
        /// </summary>
        /// <param name="Position">Location of the Body in the world</param>
        public PhysicsComponent(float PositionX, float PositionY)
            : this(PositionX, PositionY, 0f) { }

        /// <summary>
        /// Constructor, creates a basic body in the world with no physical form. Position is assumed to be 0,0.
        /// </summary>
        public PhysicsComponent()
            : this(0f, 0f) { }

        #endregion

        /// <summary>
        /// Attaches a shape to the object using the standard fixture type
        /// </summary>
        /// <param name="Shape"></param>
        public void AttachShape(Shape Shape)
        {
            _body.CreateFixture(Shape);
        }

        /// <summary>
        /// For PhysicsComponents the Execute() method does nothing
        /// Physics update logic is all managed by the PhysicsSystem
        /// </summary>
        public override void Execute()
        {}
    }
}
