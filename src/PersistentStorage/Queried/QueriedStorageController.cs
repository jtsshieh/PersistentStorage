namespace PersistentStorage.Queried
{
    /// <summary>
    /// A Queried Persistent Storage Controller
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public class QueriedStorageController<T> : PersistentStorage<T>
    {

        /// <summary>
        /// Initializes the Selected queried Persistent Storage Method
        /// </summary>
        /// <returns>A boolean of whether the operation completed successfully or failed</returns>
        public bool Initialize()
        {
            if (StorageMethod == null) return false;
            StorageMethod.Initialize();
            return true;
        }

        /// <summary>
        /// Initializes the Selected queried Persistent Storage Method with Properties 
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        /// <returns>A boolean of whether the operation completed successfully or failed</returns>
        public bool Initialize(IProperties properties)
        {
            if (StorageMethod == null) return false;
            ((IQueriedStorageMethod<T>)StorageMethod).Initialize(properties);
            return true;
        }

        /// <summary>
        /// Sets a value
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        public void SetValue<B>(string query, B value)
        {
            ((IQueriedStorageMethod<T>)StorageMethod).SetValue<B>(query, value);
        }

        /// <summary>
        /// Gets a value
        /// </summary>
        /// <typeparam name="B">They type to parse the value as</typeparam>
        /// <param name="query">The query</param>
        /// <returns>They value as a B</returns>
        public B GetValue<B>(string query)
        {
            return ((IQueriedStorageMethod<T>)StorageMethod).GetValue<B>(query);
        }

        /// <summary>
        /// Inserts an item into an array
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="item">The item being inserted into the array</param>
        /// <param name="index">The index to insert the item into</param>
        public void InsertArray<B>(string query, B item, int index)
        {
            ((IQueriedStorageMethod<T>)StorageMethod).InsertArray(query, item, index);
        }

        /// <summary>
        /// Pushes an item into an array
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="item">The item being pushed into the array</param>
        public void PushArray<B>(string query, B item)
        {
            ((IQueriedStorageMethod<T>)StorageMethod).PushArray(query, item);
        }

        /// <summary>
        /// Removes an item from an array by its index
        /// </summary>
        /// <typeparam name="B">The type of the value being removed</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="index">The index of the item that needs to be removed</param>
        public void RemoveAtArray<B>(string query, int index)
        {
            ((IQueriedStorageMethod<T>)StorageMethod).RemoveAtArray<B>(query, index);
        }

        /// <summary>
        /// Removes an item from an array
        /// </summary>
        /// <typeparam name="B">The type of the value being removed</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="item">The item that needs to be removed</param>
        public void RemoveArray<B>(string query, B item)
        {
            ((IQueriedStorageMethod<T>)StorageMethod).RemoveArray(query, item);
        }
    }
}
