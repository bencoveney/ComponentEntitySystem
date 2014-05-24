using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES
{
    abstract class Component
    {

        /// <summary>
        /// An identifier used by the system to find relevant components.
        /// This should be set to return the name of the System
        /// </summary>
        public static string Name { get { return BaseSystem.Name; } }

        /// <summary>
        /// The ID of the parent entity
        /// Only assigned when components are added to their Parent Entity
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Executes the components logic.
        /// For physics and logic components this method would contain Update() code.
        /// For graphics components this method would contain Draw() code.
        /// </summary>
        abstract public void Execute();
    }
}
