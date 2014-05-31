// <copyright file="DrawSystem.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem.CES.Draw
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// Defines the draw system
    /// </summary>
    public class DrawSystem : ISystem
    {
        /// <summary>
        /// Initializes a new instance of the DrawSystem class
        /// </summary>
        public DrawSystem()
        {
        }

        /// <summary>
        /// Gets the system's name
        /// </summary>
        public string Name
        {
            get
            {
                return "Draw";
            }
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        public void Execute()
        {
            foreach (Entity e in EntityManager.Entities)
            {
                e.ExecuteComponent(this.Name);
            }
        }
    }
}
