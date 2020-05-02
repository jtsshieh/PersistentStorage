namespace PersistentStorage.Queried
{
    /// <summary>
    /// A Queried Persistent Storage Controller
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public class QueriedStorageController<T> : PersistentStorage<T>
    {

        /// <summary>
        /// Initialize the Selected queried Persistent Storage Method
        /// </summary>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize()
        {
            if (StorageMethod == null) return false;
            StorageMethod.Initialize();
            return true;
        }

        /// <summary>
        /// Initialize the Selected queried Persistent Storage Method with Properties 
        /// </summary>
        /// <param name="properties">The IProperties object to pass in</param>
        /// <returns>A boolean of whether the operation completed succesfully or failed</returns>
        public bool Initialize(IProperties properties)
        {
            if (StorageMethod == null) return false;
            ((IQueriedStorageMethod<T>)StorageMethod).Initialize(properties);
            return true;
        }

        /// <summary>
        /// Set a value
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query</param>
        /// <param name="value">The value to set the object as</param>
        public void SetValue<B>(string query, B value)
        {
            ((IQueriedStorageMethod<T>)StorageMethod).SetValue<B>(query, value);
        }

        /// <summary>
        /// Get a value
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
        /// <param name="rootObject">The object to set the value on</param>
        /// <param name="item">The item being inserted into the array</param>
        /// <param name="index">The index to insert the item into</param>
        /// <returns>The object with the item inserted</returns>
        public object InsertArray<B>(string query, object rootObject, B item, int index)
        {
            return ((IQueriedStorageMethod<T>)StorageMethod).InsertArray<B>(query, rootObject, item, index);
        }

        /// <summary>
        /// Push an item into an array
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="rootObject">The object to set the value on</param>
        /// <param name="item">The item being pushed into the array</param>
        /// <returns>The object with the item pushed</returns>
        public object PushArray<B>(string query, object rootObject, B item)
        {
            return ((IQueriedStorageMethod<T>)StorageMethod).PushArray<B>(query, rootObject, item);
        }

        /// <summary>
        /// Remove an item from an array by its index
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="rootObject">The object to set the value on</param>
        /// <param name="index">The index of the item that needs to be removed</param>
        /// <returns>The object with the item removed</returns>
        public object RemoveAtArray<B>(string query, object rootObject, int index)
        {
            return ((IQueriedStorageMethod<T>)StorageMethod).RemoveAtArray<B>(query, rootObject, index);
        }

        /// <summary>
        /// Remove an item from an array
        /// </summary>
        /// <typeparam name="B">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="rootObject">The object ot set the value on</param>
        /// <param name="item">The item that needs to be removed</param>
        /// <returns>The object with the item removed</returns>
        public object RemoveArray<B>(string query, object rootObject, B item)
        {
            return ((IQueriedStorageMethod<T>)StorageMethod).RemoveArray<B>(query, rootObject, item);
        }
    }
}
