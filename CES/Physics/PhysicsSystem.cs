// <copyright file="PhysicsSystem.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem.CES.Physics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the physics system
    /// </summary>
    public class PhysicsSystem : ISystem
    {
        /// <summary>
        /// Initializes a new instance of the PhysicsSystem class
        /// </summary>
        public PhysicsSystem()
        {
        }

        /// <summary>
        /// Gets the system's name
        /// </summary>
        public string Name
        {
            get
            {
                return "Physics";
            }
        }

        /// <summary>
        /// Runs the physics system for 1 tick
        /// </summary>
        public void Execute()
        {
            // Update the world at 60Hz
            Game.World.Step(0.0166f);
        }
    }
}
