using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentEntitySystem.CES
{
    static class EntityManager
    {
        private static Dictionary<int, Entity> _entities;
        public static List<Entity> Entities { get { return _entities.Values.ToList(); } }

        static EntityManager()
        {
            _entities = new Dictionary<int, Entity>();
        }

        /// <summary>
        /// Adds an entity to the game
        /// </summary>
        /// <param name="entity">The entity to add</param>
        public static void AddEntity(Entity entity)
        {
            _entities.Add(entity.ID, entity);
        }

        /// <summary>
        /// Finds the entity with the given ID
        /// </summary>
        /// <param name="ID">The ID to find</param>
        /// <returns>The found entity</returns>
        public static Entity GetEntityById(int ID)
        {
            return _entities[ID];
        }

        /// <summary>
        /// Removes an entity from the game
        /// </summary>
        /// <param name="ID">The ID to remove</param>
        public static void RemoveEntityById(int ID)
        {
            _entities.Remove(ID);
        }

        #region UniqueIdProvider

        private static int _id = 0;
        /// <summary>
        /// Gives a Unique ID to be used by entities as an Identifier
        /// </summary>
        /// <returns></returns>
        public static int GetNextId()
        {
            return _id++;
        }

        #endregion
    }
}
