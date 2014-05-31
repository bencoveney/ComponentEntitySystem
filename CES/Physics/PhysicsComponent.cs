// <copyright file="PhysicsComponent.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem.CES.Physics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FarseerPhysics.Collision.Shapes;
    using FarseerPhysics.Dynamics;

    /// <summary>
    /// Defines a component in the physics system
    /// </summary>
    public class PhysicsComponent : IComponent
    {
        #region Data Members

        /// <summary>
        /// A reference to this physics object's presence in the physics simulation
        /// </summary>
        private Body body;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PhysicsComponent class
        /// </summary>
        /// <param name="positionX">The position of the object on the X axis</param>
        /// <param name="positionY">The position of the object on the Y axis</param>
        /// <param name="rotation">The rotation of the object</param>
        /// <param name="isStatic">Should the object be static or dynamic?</param>
        public PhysicsComponent(float positionX, float positionY, float rotation, bool isStatic)
        {
            this.body = new Body(Game.World, new Microsoft.Xna.Framework.Vector2(positionX, positionY), rotation);
            this.body.BodyType = isStatic ? BodyType.Static : BodyType.Dynamic;
        }

        /// <summary>
        /// Initializes a new instance of the PhysicsComponent class
        /// </summary>
        /// <param name="positionX">The position of the object on the X axis</param>
        /// <param name="positionY">The position of the object on the Y axis</param>
        /// <param name="rotation">The rotation of the object</param>
        public PhysicsComponent(float positionX, float positionY, float rotation)
            : this(positionX, positionY, rotation, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PhysicsComponent class
        /// </summary>
        /// <param name="positionX">The position of the object on the X axis</param>
        /// <param name="positionY">The position of the object on the Y axis</param>
        public PhysicsComponent(float positionX, float positionY)
            : this(positionX, positionY, 0f) 
        {
        }

        /// <summary>
        /// Initializes a new instance of the PhysicsComponent class
        /// </summary>
        public PhysicsComponent()
            : this(0f, 0f) 
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Physics Simulation object this component references
        /// </summary>
        public Body Body
        {
            get
            {
                return this.body;
            }
        }

        /// <summary>
        /// Gets the name of this component
        /// </summary>
        public string Name
        {
            get
            {
                return "Physics";
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

        #endregion

        #region Methods

        /// <summary>
        /// Attaches a shape to the object using the standard fixture type
        /// </summary>
        /// <param name="shape">The shape to attach</param>
        public void AttachShape(Shape shape)
        {
            this.body.CreateFixture(shape);
        }

        /// <summary>
        /// For PhysicsComponents the Execute() method does nothing
        /// Physics update logic is all managed by the PhysicsSystem
        /// </summary>
        public void Execute()
        {
        }

        #endregion
    }
}
