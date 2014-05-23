using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES
{
    class IComponent
    {
        public string Name;
        public int ParentId;

        /// <summary>
        /// Executes the components logic.
        /// For physics and logic components this method would contain Update() code.
        /// For graphics components this method would contain Draw() code.
        /// </summary>
        public void Execute();
    }
}
