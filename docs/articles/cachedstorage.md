# Cached Storage

A cached storage controller allows you to access data with a cache for easy access. No queries are needed.

## Controller

The `CachedStorageController` exposes the methods of the `ICachedStorageMethod`. It extends the base controller class `PersistentStorage`.

### Initialization

Initializing the controller is as easy as calling the `Initialize` function on the controller. This initializes the selected storage method. Depending on the Storage Method, it will complete tasks such as loading the cache or creating a file. It will also load the cache into the `CurrentCache` property.

Some storage methods need to be initialized with properties. In that case, you will need to instantiate the properties class for that storage method, fill out any necessary information, and then pass that class as a parameter in `Initialize`.

This method will either return `true` or `false` indicating whether a StorageMethod was selected.

### Accessing data

The `CachedStorageController` controller contains a cache that is parsed as the type that is passed as a type param when instantiating the base object. This cache is the property `CurrentCache`. It is only updated when the controller is initialized, the `SaveState` function is called, or when `UpdateCache` is called. So all you have to do to access data is to access the `CurrentCache` property on the controller.

### Updating data

Updating data requires just a simple update on the `CurrentCache` object. After finishing your updates on the `CurrentCache` object, you need to call the `SaveState` method to save the cache into the PersistentStorage.

### Loading data to cache

To load data from your Persistent Storage Method to the cache, you can call the `UpdateCache` method.
