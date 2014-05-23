using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES
{
    abstract class System
    {
        /// <summary>
        /// An identifier used by the system to find relevant components
        /// </summary>
        abstract public static string Name { get { return "SystemName"; } }

        /// <summary>
        /// Performs the actions encompassed by the system
        /// </summary>
        abstract public void Execute()
        {
            foreach (Entity e in EntityManager.Entities)
            {
                e.ExecuteComponent(Name);
            }
        }
    }
}
