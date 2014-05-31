// <copyright file="EntityManager.cs" company="Not Applicable">
//     No Current Copyright
// </copyright>

namespace ComponentEntitySystem.CES
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A management class for entities
    /// </summary>
    public static class EntityManager
    {
        /// <summary>
        /// All current entities indexed by their Unique Identifier
        /// </summary>
        private static Dictionary<int, Entity> entities;

        /// <summary>
        /// Tracks which unique IDs have been assigned
        /// </summary>
        private static int id = 0;

        /// <summary>
        /// Initializes static members of the EntityManager class
        /// </summary>
        static EntityManager()
        {
            entities = new Dictionary<int, Entity>();
        }

        /// <summary>
        /// Gets all entities
        /// </summary>
        public static List<Entity> Entities
        {
            get
            {
                return entities.Values.ToList();
            }
        }

        /// <summary>
        /// Adds an entity to the game
        /// </summary>
        /// <param name="entity">The entity to add</param>
        public static void AddEntity(Entity entity)
        {
            entities.Add(entity.ID, entity);
        }

        /// <summary>
        /// Finds the entity with the given ID
        /// </summary>
        /// <param name="id">The ID to find</param>
        /// <returns>The found entity</returns>
        public static Entity GetEntityById(int id)
        {
            return entities[id];
        }

        /// <summary>
        /// Removes an entity from the game
        /// </summary>
        /// <param name="id">The ID to remove</param>
        public static void RemoveEntityById(int id)
        {
            entities.Remove(id);
        }

        /// <summary>
        /// Gives a Unique ID to be used by entities as an Identifier
        /// </summary>
        /// <returns>The next unique identifier</returns>
        public static int GetNextId()
        {
            return EntityManager.id++;
        }
    }
}
