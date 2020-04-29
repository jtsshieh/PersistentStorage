namespace PersistentStorage.Cached
{
    /// <summary>
    /// The base for a Cached Storage Method
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public interface ICachedStorageMethod<T> : IStorageMethod<T>
    { 
        /// <summary>
        /// The Current Cache object
        /// </summary>
        T CurrentCache { get; set; }

        /// <summary>
        /// Gets the Current Cache of the Storage Method
        /// </summary>
        /// <returns>The Current Cache</returns>
        T GetCache();

        /// <summary>
        /// Sets the Cache 
        /// </summary>
        /// <param name="cacheObject">The CacheObject to set the cache as</param>
        void SetCache(T cacheObject);

        /// <summary>
        /// Saves the stored cache into the Persistent Storage
        /// </summary>
        void SaveState();

        /// <summary>
        /// Gets the data from the Persistent Storage and dumps it to the Cache
        /// </summary>
        void UpdateCache();

        /// <summary>
        /// Initialize the Cached StorageMethod with Properties
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        /// <see cref="IProperties"/>
        void Initialize(IProperties properties);
    }
}
