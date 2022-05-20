using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Repositories
{
    public interface CrudRepository<T>
    {
        /// <summary>
        /// We return all entities without connecting to children.
        /// 
        /// For example, if Class1 -> Class2, then Class1 will have null in the field with Class2
        /// </summary>
        /// 
        /// <returns>List Entities</returns>
        public List<T> GetAll();

        /// <summary>
        /// We return the entity by its identifier, without connecting to the children. See <see cref="GetAll"/>
        /// </summary>
        /// 
        /// <param name="id">Entity Identifier</param>
        /// 
        /// <returns>Entity</returns>
        /// 
        /// <exception cref="System.Exception">Thrown when there is no entity for the given id in the repository</exception>
        public T GetById(int id);

        /// <summary>
        /// Adds or updates an entity. 
        /// 
        /// Whether the entity was added earlier is determined by the identifier: 
        /// if it is already present in the repository, then the entity is updated, otherwise it is added.
        /// </summary>
        /// 
        /// <param name="entity">Entity to be saved</param>
        /// 
        /// <returns>New entity (current state in repository)</returns>
        public T Save(T entity);

        /// <summary>
        /// Delete entity. It must contain only the identifier.
        /// </summary>
        /// 
        /// <param name="entity">Entity to be removed</param>
        public void Delete(T entity);
    }
}