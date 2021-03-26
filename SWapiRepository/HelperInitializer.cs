using System;
using System.Linq.Expressions;

namespace SWapiRepository
{
    
    /// <summary>
    /// This static helper initializer is 3x faster than <see cref="System.Activator.CreateInstance{T}"/>.
    /// </summary>
    /// <typeparam name="T">Generic object inherits <see cref="StarWarsApiCSharp.BaseEntity"/></typeparam>
    public static class HelperInitializer<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the instance of T.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static readonly Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }
}
