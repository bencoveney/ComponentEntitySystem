using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES.Draw
{
    class DrawComponent
    {
        public string Name { get { return "Draw"; } }
        
        public int ParentId { get; set; }

        public DrawComponent()
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
