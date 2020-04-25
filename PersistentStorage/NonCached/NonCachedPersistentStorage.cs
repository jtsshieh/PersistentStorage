namespace PersistentStorage.NonCached
{
    /// <summary>
    /// A Non Cached Persistent Storage Controller
    /// </summary>
    /// <typeparam name="T">The Base Object</typeparam>
    public class NonCachedPersistentStorage<T> : PersistentStorage<T>
    {

        /// <summary>
        /// Initialize the Selected Cached Persistent Storage Method
        /// </summary>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize()
        {
            if (StorageMethod == null) return false;
            StorageMethod.Initialize();
            return true;
        }

        /// <summary>
        /// Initialize the Selected Cache Persistent Storage Method with Properties 
        /// </summary>
        /// <param name="Properties">The IProperties object to pass in</param>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize(IProperties Properties)
        {
            if (StorageMethod == null) return false;
            ((INonCachedStorageMethod<T>)StorageMethod).Initialize(Properties);
            return true;
        }

        public void SetValue(string Query, string Value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetValue(Query, Value);
        }

        public void SetValue(string Query, int Value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetValue(Query, Value);
        }

        public void SetValue(string Query, bool Value)
        {
            ((INonCachedStorageMethod<T>)StorageMethod).SetValue(Query, Value);
        }
       
        public string GetString(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetString(Query);
        }

        public int GetInt(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetInt(Query);
        }

        public bool GetBool(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetBool(Query);
        }

        public object GetType(string Query)
        {
            return ((INonCachedStorageMethod<T>)StorageMethod).GetType(Query);
        }
    }
}
