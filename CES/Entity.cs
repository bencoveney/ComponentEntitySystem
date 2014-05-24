using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES
{
    class Entity
    {
        #region Data Members

        private int _id;
        public int ID { get { return _id; } }

        private List<Component> _components;
        public List<Component> Components { get { return _components; } }

        #endregion

        #region Constructor

        public Entity()
        {
            _id = EntityManager.GetNextId();
            _components = new List<Component>();
        }

        #endregion

        #region Component Management

        /// <summary>
        /// Adds a component to the entity
        /// </summary>
        /// <param name="component">The component to add</param>
        public void AddComponent(Component component)
        {
            component.ParentId = _id;
            _components.Add(component);
        }
        
        /// <summary>
        /// Returns the first component found which has a given name
        /// </summary>
        /// <param name="Name">The name to find</param>
        /// <returns>The first component found</returns>
        public Component GetComponentByName(string Name)
        {
            return _components.Find(c => c.Name.Equals(Name));
        }

        /// <summary>
        /// Returns all components which have the given name
        /// </summary>
        /// <param name="Name">The name to find</param>
        /// <returns>The components</returns>
        public List<Component> GetComponentsByName(string Name)
        {
            return _components.FindAll(c => c.Name.Equals(Name));
        }

        /// <summary>
        /// Removes all components with a given name
        /// </summary>
        /// <param name="Name">The name to remove</param>
        public void RemoveComponents(string Name)
        {
            _components.RemoveAll(c => c.Name.Equals(Name));
        }

        #endregion

        #region Component Execution

        /// <summary>
        /// Will call the Execute method of any components with the specified name
        /// </summary>
        /// <param name="Name">The name of components to execute</param>
        public void ExecuteComponent(string Name)
        {
            foreach (Component c in _components.FindAll(c => c.Name.Equals(Name)))
            {
                c.Execute();
            }
        }

        #endregion
    }
}
