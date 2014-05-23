using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES.Draw
{
    class DrawSystem
    {
        public void Execute()
        {
            foreach (Entity e in EntityManager.Entities)
            {
                e.ExecuteComponent("Draw");
            }
        }
    }
}
