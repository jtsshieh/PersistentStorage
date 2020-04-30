# Non Cached Storage

A non cached storage controller allows you to access data without a local cache. Data is accessed through [queries](noncachedqueries.md).

## Controller

The `NonCachedPersistentStorage` controller exposes the methods of the `INonCachedStorageMethod`. It extends the base controller class `PersistentStorage`.

### Initialization

Initializing the controller is as easy as calling the `Initialize` function on the controller. This initializes the selected storage method. Depending on the Storage Method, it will complete tasks such as creating files or databases.

Some Storage Methods need to be initialized with properties. In that case, you will need to instantiate the properties class for that storage method, fill out any necessary information, and then pass that class as a parameter in `Initialize`.

This method will either return `true` or `false` indicating whether a StorageMethod was selected.

### Accessing data

The controller has four methods for accessing data. They are `GetString`, `GetInt`, `GetBool`, and `GetValue<B>`. They all take in a [query](noncachedqueries.md) and will return the result that is expressed in their method name. `GetValue<B>` takes in a type parameter in addition to the query. The result will be parsed as the type `B`.

### Updating data

The controller has three methods for setting/updating data. They are `SetString`, `SetInt`, and `SetBool`. They all take in a [query](noncachedqueries.md) and a value. The value is the type that is expressed in the method name.
