using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES.Physics
{
    class PhysicsComponent : IComponent
    {
        public string Name { get { return "Physics"; } }

        public int ParentId { get; set; }

        public PhysicsComponent()
        {
        }

        /// <summary>
        /// For PhysicsComponents the Execute() method does nothing
        /// Physics update logic is all managed by the PhysicsSystem
        /// </summary>
        public void Execute()
        {
        }
    }
}
