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
        /// <param name="Properties">The IProperties object to pass in</param>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize(IProperties Properties)
        {
            if (StorageMethod == null) return false;
            ((INonCachedStorageMethod<T>)StorageMethod).Initialize(Properties);
            return true;
        }

        /// <summary>
        /// Set a string value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <param name="Value">The value to set the object as</param>
        public void SetValue(string Query, string Value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetValue(Query, Value);
        }

        /// <summary>
        /// Set an integer value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <param name="Value">The value to set the object as</param>
        public void SetValue(string Query, int Value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetValue(Query, Value);
        }

        /// <summary>
        /// Set a boolean value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <param name="Value">The value to set the object as</param>
        public void SetValue(string Query, bool Value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetValue(Query, Value);
        }
       
        /// <summary>
        /// Get a string value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as a string</returns>
        public string GetString(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetString(Query);
        }

        /// <summary>
        /// Get an integer value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as an integer</returns>
        public int GetInt(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetInt(Query);
        }

        /// <summary>
        /// Get a boolean value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as a boolean</returns>
        public bool GetBool(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetBool(Query);
        }

        /// <summary>
        /// Get a value as an object
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as an object</returns>
        public object GetType(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetType(Query);
        }
    }
}
