# PersistentStorage

The base PersistentStorage controller is the base controller for accessing data. It should not be used by itself.

## Controller

The base PersistentStorage controller contains methods that allow the switching of storage methods. When instantiating the class, you need to pass in a the type of the base object as the type parameter.

## Managing Storage Methods

### Instantiating the class

The PersistentStorage controller allows hot-swapping storage methods. When instantiating the class, it is possible to pass in Storage Methods as params.

### Adding Storage Methods

To add a Storage method, simple call the `AddStorageMethod` method and pass in an `IStorageMethod<T>`. Then, it will be added to the Storage Method registry.

### Selecting Storage Methods

There are two ways to select a storage method. If you have the instance of the storage method, it is highly recommended that you use that and pass it into the `SelectStorageMethod` function on the controller

If you don't have the instance of the Storage Method, it is also possible to select a Storage Method by its name. But if there are no Storage Methods that match the name, none will be selected so you should check the `StorageMethod` property on the controller to see if the method was selected. To select a Storage Method by its name, you also use the `SelectStorageMethod` function on the controller.
