namespace PersistentStorage.NonCached
{
    /// <summary>
    /// The base for a Non Cached Storage Method
    /// </summary>
    /// <typeparam name="T">The Base Object</typeparam>
    public interface INonCachedStorageMethod<T> : IStorageMethod<T>
    {
        /// <summary>
        /// Initialize the Non Cached StorageMethod with Properties
        /// </summary>
        /// <param name="Properties">The IProperties object to pass in</param>
        void Initialize(IProperties Properties);

        /// <summary>
        /// Set a string value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <param name="Value">The value to set the object as</param>
        void SetValue(string Query, string Value);

        /// <summary>
        /// Set an integer value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <param name="Value">The value to set the object as</param>
        void SetValue(string Query, int Value);

        /// <summary>
        /// Set a boolean value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <param name="Value">The value to set the object as</param>
        void SetValue(string Query, bool Value);

        /// <summary>
        /// Get a string value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as a string</returns>
        string GetString(string Query);

        /// <summary>
        /// Get an integer value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as an integer</returns>
        int GetInt(string Query);

        /// <summary>
        /// Get a boolean value
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as a boolean</returns>
        bool GetBool(string Query);

        /// <summary>
        /// Get a value as an object
        /// </summary>
        /// <param name="Query">The query</param>
        /// <returns>The value as an object</returns>
        object GetType(string Query);
    }
}
