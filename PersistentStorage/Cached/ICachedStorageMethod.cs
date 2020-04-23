using System;
using System.Collections.Generic;
using System.Text;

namespace PersistentStorage
{
    /// <summary>
    /// The base for a Cached Storage Method
    /// </summary>
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
        /// <param name="CacheObject">The CacheObject to set as a Serializable</param>
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
