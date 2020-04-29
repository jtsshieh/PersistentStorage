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
        /// Set a string value
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        public void SetString(string query, string value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetString(query, value);
        }

        /// <summary>
        /// Set an integer value
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        public void SetInt(string query, int value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetInt(query, value);
        }

        /// <summary>
        /// Set a boolean value
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        public void SetBool(string query, bool value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetBool(query, value);
        }
       
        /// <summary>
        /// Get a string value
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The value as a string</returns>
        public string GetString(string query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetString(query);
        }

        /// <summary>
        /// Get an integer value
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The value as an integer</returns>
        public int GetInt(string query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetInt(query);
        }

        /// <summary>
        /// Get a boolean value
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The value as a boolean</returns>
        public bool GetBool(string query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetBool(query);
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
