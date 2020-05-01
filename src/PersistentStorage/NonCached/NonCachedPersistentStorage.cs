namespace PersistentStorage.NonCached
{
    /// <summary>
    /// A Non Cached Persistent Storage Controller
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public class NonCachedPersistentStorage<T> : PersistentStorage<T>
    {

        /// <summary>
        /// Initialize the Selected Non Cached Persistent Storage Method
        /// </summary>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize()
        {
            if (StorageMethod == null) return false;
            StorageMethod.Initialize();
            return true;
        }

        /// <summary>
        /// Initialize the Selected Non Cached Persistent Storage Method with Properties 
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize(IProperties properties)
        {
            if (StorageMethod == null) return false;
            ((INonCachedStorageMethod<T>)StorageMethod).Initialize(properties);
            return true;
        }

        /// <summary>
        /// Set a value
        /// </summary>
        /// <typeparam name="B">The type of the value being set/typeparam>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        public void SetValue<B>(string query, B value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetValue<B>(query, value);
        }

        /// <summary>
        /// Get a value
        /// </summary>
        /// <typeparam name="B">They type to parse the value as</typeparam>
        /// <param name="query">The query</param>
        /// <returns>They value as a B</returns>
        public B GetValue<B>(string query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetValue<B>(query);
        }
    }
}
