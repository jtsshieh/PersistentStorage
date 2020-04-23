namespace PersistentStorage
{
    /// <summary>
    /// A Cached Persistent Storage Controller
    /// </summary>
    /// <typeparam name="T">The Base Object</typeparam>
    public class CachedPersistentStorage<T> : PersistentStorage<T>
    {
        /// <summary>
        /// The Current Cache Object
        /// </summary>
        public T CurrentCache;

        /// <summary>
        /// Initialize the Selected Cached Persistent Storage Method
        /// </summary>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize()
        {
            if (StorageMethod == null) return false;
            StorageMethod.Initialize();
            ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
            CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
            return true;
        }

        /// <summary>
        /// Initialze the Selected Cache Persistent Storage Method with a DataFile
        /// </summary>
        /// <param name="DataFile">The path to the data fil</param>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize(string DataFile)
        {
            if (StorageMethod == null) return false;
            if (StorageMethod is ICachedStorageMethodFile<T>)
            {
                ((ICachedStorageMethodFile<T>)StorageMethod).Initialize(DataFile);
                ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
                CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Save the Cache into the Persistent Storage
        /// </summary>
        public void SaveState()
        {
            ((ICachedStorageMethod<T>)StorageMethod).SetCache(CurrentCache);
            ((ICachedStorageMethod<T>)StorageMethod).SaveState();
        }

        /// <summary>
        /// Update the Cache with the contents of the Persistent Storage
        /// </summary>
        public void UpdateCache()
        {
            ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
            CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
        }

        /// <summary>
        /// Save and Update the Cache
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
