// <copyright file="Entity.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>using System;

namespace ComponentEntitySystem.CES
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the entity object
    /// </summary>
    public class Entity
    {
        #region Data Members

        /// <summary>
        /// The entity's unique identifier
        /// </summary>
        private int id;

        /// <summary>
        /// The collection of components the entity has assigned
        /// </summary>
        private List<IComponent> components;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Entity class.
        /// </summary>
        public Entity()
        {
            this.id = EntityManager.GetNextId();
            this.components = new List<IComponent>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets all components the entity has assigned
        /// </summary>
        public List<IComponent> Components
        {
            get
            {
                return this.components;
            }
        }

        /// <summary>
        /// Gets this entity's unique identifier
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }
        }

        #endregion

        #region Component Management

        /// <summary>
        /// Adds a component to the entity
        /// </summary>
        /// <param name="component">The component to add</param>
        public void AddComponent(IComponent component)
        {
            component.ParentId = this.id;
            this.components.Add(component);
        }
        
        /// <summary>
        /// Returns the first component found which has a given name
        /// </summary>
        /// <param name="name">The name to find</param>
        /// <returns>The first component found</returns>
        public IComponent GetComponentByName(string name)
        {
            return this.components.Find(c => c.Name.Equals(name));
        }

        /// <summary>
        /// Returns all components which have the given name
        /// </summary>
        /// <param name="name">The name to find</param>
        /// <returns>The components</returns>
        public List<IComponent> GetComponentsByName(string name)
        {
            return this.components.FindAll(c => c.Name.Equals(name));
        }

        /// <summary>
        /// Removes all components with a given name
        /// </summary>
        /// <param name="name">The name to remove</param>
        public void RemoveComponents(string name)
        {
            this.components.RemoveAll(c => c.Name.Equals(name));
        }

        #endregion

        #region Component Execution

        /// <summary>
        /// Will call the Execute method of any components with the specified name
        /// </summary>
        /// <param name="name">The name of components to execute</param>
        public void ExecuteComponent(string name)
        {
            foreach (IComponent c in this.components.FindAll(c => c.Name.Equals(name)))
            {
                c.Execute();
            }
        }

        #endregion
    }
}
