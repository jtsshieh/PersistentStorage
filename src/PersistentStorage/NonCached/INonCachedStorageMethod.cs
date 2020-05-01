namespace PersistentStorage.NonCached
{
    /// <summary>
    /// The base for a Non Cached Storage Method
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public interface INonCachedStorageMethod<T> : IStorageMethod<T>
    {
        /// <summary>
        /// Initialize the Non Cached storage method with Properties
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        void Initialize(IProperties properties);

        /// <summary>
        /// Set a value
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query</param>
        /// <param name="value">The value as a B</param>
        void SetValue<B>(string query, B value);

        /// <summary>
        /// Get a value
        /// </summary>
        /// <typeparam name="B">They type to parse the value as</typeparam>
        /// <param name="query">The query</param>
        /// <returns>The value as a B</returns>
        B GetValue<B>(string query);
    }
}
