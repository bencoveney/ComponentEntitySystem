using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES.Draw
{
    static class DrawSystem : BaseSystem
    {
        static DrawSystem()
        {
            Name = "DrawSystem";
        }

        public static void Execute()
        {
            foreach (Entity e in EntityManager.Entities)
            {
                e.ExecuteComponent(Name);
            }
        }
    }
}
