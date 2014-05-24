using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES
{
    abstract class BaseSystem
    {
        public static string Name { get; set; }

        public BaseSystem()
        {
            Name = "SystemName";
        }

        /// <summary>
        /// Performs the actions encompassed by the system
        /// </summary>
        virtual public void Execute()
        {
            foreach (Entity e in EntityManager.Entities)
            {
                e.ExecuteComponent(BaseSystem.Name);
            }
        }
    }
}
