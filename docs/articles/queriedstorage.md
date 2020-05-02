# Queried Storage

A queried controller allows you to access data through [queries](queries.md). Depending on your storage method implementation, queries could be implemented using the `QueryParser` class which, or the Storage Method could have a custom query system.

## Controller

The `QueriedStorageController` exposes the methods of the `IQueriedStorageMethod`. It extends the base controller class `PersistentStorage`.

### Initialization

Initializing the controller is as easy as calling the `Initialize` function on the controller. This initializes the selected storage method. Depending on the Storage Method, it will complete tasks such as creating files or databases.

Some storage methods need to be initialized with properties. In that case, you will need to instantiate the properties class for that storage method, fill out any necessary information, and then pass that class as a parameter in `Initialize`.

This method will either return `true` or `false` indicating whether a storage method was selected.

### Accessing data

To get data, use the `GetValue<B>` function on the controller, passing in a query and the type parameter, `B` indicating what type the result should be parsed as. `GetValue<B>` returns a result, if it exists, parsed into the type param specified.

### Updating data

To set/update data, use the `SetValue<B>` function on the controller, passing in a query, the value to set the object as, and a type `B`, indicating what type you want the value to be set as.

### Modifying Arrays

The `QueriedStorageController` contains 4 methods to modify arrays.

#### InsertArray

`InsertArray` inserts an item into the array at a specific index. The `InsertArray` method signature is `InsertArray<T>(string query, T item, int index)`. `T` is the type of the object being pushed, `query` is a query selecting the array, `item` is the item that you want to push into the array, and `index` is the index you want to insert the item into.

#### PushArray

`PushArray` pushes an item into the array at the end. The `PushArray` method signature is `PushArray<T>(string query, T item)`. `T` is the type of the object being pushed, `query` is a query selecting the array, and `item` is the item that you want to push into the array.

#### RemoveAtArray

`RemoveAtArray` removes an item in the array by its index. The `RemoveAtArray` method signature is `RemoveAtArray<T>(string query, int index)`. `T` is the type of the object being removed, `query` is a query selecting the array, and `index` is the index you want to remove the item at.

#### RemoveArray

`RemoveArray` removes an item in the array. The `RemoveArray` method signature is `RemoveArray<T>(string query, T item)`. `T` is the type of the object being removed, `query` is a query selecting the array, and `item` is the item that you want to remove from the array.
