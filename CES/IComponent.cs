// <copyright file="IComponent.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>using System;

namespace ComponentEntitySystem.CES
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the public properties and methods a component must have
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Gets the component's name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the id of the parent entity
        /// </summary>
        int ParentId { get; set; }

        /// <summary>
        /// Contains the update logic for the component
        /// </summary>
        void Execute();
    }
}
