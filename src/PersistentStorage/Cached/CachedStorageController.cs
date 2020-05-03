namespace PersistentStorage.Cached
{
    /// <summary>
    /// A Cached Persistent Storage Controller
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public class CachedStorageController<T> : PersistentStorage<T>
    {
        /// <summary>
        /// The Current Cache Object
        /// </summary>
        public T CurrentCache;

        /// <summary>
        /// Initializs the Selected Cached Persistent Storage Method
        /// </summary>
        /// <returns>A boolean of whether the operation completed successfully or failed</returns>
        public bool Initialize()
        {
            if (StorageMethod == null) return false;
            StorageMethod.Initialize();
            ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
            CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
            return true;
        }

        /// <summary>
        /// Initializes the Selected Cached Persistent Storage Method with Properties 
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        /// <see cref="IProperties"/>
        /// <returns>A boolean of whether the operation completed successfully or failed</returns>
        public bool Initialize(IProperties properties)
        {
            if (StorageMethod == null) return false;
            ((ICachedStorageMethod<T>)StorageMethod).Initialize(properties);
            ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
            CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
            return true;
        }

        /// <summary>
        /// Saves the Cache into the Persistent Storage
        /// </summary>
        public void SaveState()
        {
            ((ICachedStorageMethod<T>)StorageMethod).SetCache(CurrentCache);
            ((ICachedStorageMethod<T>)StorageMethod).SaveState();
        }

        /// <summary>
        /// Updates the Cache with the contents of the Persistent Storage
        /// </summary>
        public void UpdateCache()
        {
            ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
            CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
        }

        /// <summary>
        /// Saves and Updates the Cache
        /// <see cref="SaveState"/>
        /// <see cref="UpdateCache"/>
        /// </summary>
        public void SaveUpdate()
        {
            SaveState();
            UpdateCache();
        }
    }
}
