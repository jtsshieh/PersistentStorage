namespace PersistentStorage.NonCached
{
    /// <summary>
    /// The base for a Non Cached Storage Method
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public interface INonCachedStorageMethod<T> : IStorageMethod<T>
    {
        /// <summary>
        /// Initialize the Non Cached storage method with Properties
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        void Initialize(IProperties properties);

        /// <summary>
        /// Set a string value
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        void SetString(string query, string value);

        /// <summary>
        /// Set an integer value
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        void SetInt(string query, int value);

        /// <summary>
        /// Set a boolean value
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        void SetBool(string query, bool value);

        /// <summary>
        /// Get a string value
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The value as a string</returns>
        string GetString(string query);

        /// <summary>
        /// Get an integer value
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The value as an integer</returns>
        int GetInt(string query);

        /// <summary>
        /// Get a boolean value
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The value as a boolean</returns>
        bool GetBool(string query);

        /// <summary>
        /// Get a value
        /// </summary>
        /// <typeparam name="B">They type to parse the value as</typeparam>
        /// <param name="query">The query</param>
        /// <returns>They value as a B</returns>
        B GetValue<B>(string query);
    }
}
