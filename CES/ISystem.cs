// <copyright file="ISystem.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem.CES
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the public properties and methods a system must have
    /// </summary>
    public interface ISystem
    {
        /// <summary>
        /// Gets the name of the system
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Contains the update logic for the system
        /// </summary>
        void Execute();
    }
}
