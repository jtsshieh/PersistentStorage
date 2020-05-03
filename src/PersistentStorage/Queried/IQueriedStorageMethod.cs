namespace PersistentStorage.Queried
{
    /// <summary>
    /// The base for a Queried Storage Method
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public interface IQueriedStorageMethod<T> : IStorageMethod<T>
    {
        /// <summary>
        /// Initialize the queried storage method with properties
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        /// <see cref="IProperties"/>
        void Initialize(IProperties properties);

        /// <summary>
        /// Set a value
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query</param>
        /// <param name="value">The value as a B</param>
        void SetValue<B>(string query, B value);

        /// <summary>
        /// Get a value
        /// </summary>
        /// <typeparam name="B">They type to parse the value as</typeparam>
        /// <param name="query">The query</param>
        /// <returns>The value as a B</returns>
        B GetValue<B>(string query);

        /// <summary>
        /// Inserts an item into an array
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="item">The item being inserted into the array</param>
        /// <param name="index">The index to insert the item into</param>
        void InsertArray<B>(string query, B item, int index);

        /// <summary>
        /// Push an item into an array
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="item">The item being pushed into the array</param>
        void PushArray<B>(string query, B item);

        /// <summary>
        /// Remove an item from an array by its index
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="index">The index of the item that needs to be removed</param>
        void RemoveAtArray<B>(string query, int index);

        /// <summary>
        /// Remove an item from an array
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="item">The item that needs to be removed</param>
        void RemoveArray<B>(string query, B item);
    }
}
