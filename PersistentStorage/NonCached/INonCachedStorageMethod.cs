namespace PersistentStorage.NonCached
{
    /// <summary>
    /// The base for a Non Cached Storage Method
    /// </summary>
    /// <typeparam name="T">The Base Object</typeparam>
    public interface INonCachedStorageMethod<T> : IStorageMethod<T>
    {
        /// <summary>
        /// Initialize the NonCached StorageMethod with Properties
        /// </summary>
        /// <param name="Properties">The IProperties object to pass in</param>
        void Initialize(IProperties Properties);

        void SetValue(string Query, string Value);
        void SetValue(string Query, int Value);
        void SetValue(string Query, bool Value);

        string GetString(string Query);
        int GetInt(string Query);
        bool GetBool(string Query);
        object GetType(string Query);
    }
}
