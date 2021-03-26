using System.Collections.Generic;

namespace SWapiRepository
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T"><see cref="StarWarsApiCSharp.BaseEntity" />Base entity.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the entity by it's identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="StarWarsApiCSharp.BaseEntity" />Base entity.</returns>
        T GetById(int id);

        /// <summary>
        /// Gets entities.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size of entities.</param>
        /// <returns>ICollection&lt; <see cref="StarWarsApiCSharp.BaseEntity" /> &gt;.</returns>
        ICollection<T> GetEntities(int page = 1, int size = 10);

        //ICollection<Film> GetAllSWFilms();
    }
}
