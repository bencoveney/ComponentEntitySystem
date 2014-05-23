using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES.Physics
{
    class PhysicsSystem
    {
        public void Execute()
        {
            // Update the world at 60Hz
            Game.World.Step(0.0166f);
        }
    }
}
