namespace PersistentStorage
{
    /// <summary>
    /// The base for a Cached Storage Method
    /// </summary>
    /// <typeparam name="T">The Base Object</typeparam>
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
        /// <param name="CacheObject">The CacheObject to set the cache as</param>
        void SetCache(T CacheObject);
        /// <summary>
        /// Saves the stored cache into the Persistent Storage
        /// </summary>
        void SaveState();
        /// <summary>
        /// Gets the data from the Persistent Storage and dumps it to the Cache
        /// </summary>
        void UpdateCache();
    }
}
