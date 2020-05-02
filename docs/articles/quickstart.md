# Quick Start

Before you start, make sure you installed `Garamia.PersistentStorage`, either through NuGet, or by compiling from source.

## Installing a StorageMethod

In order to store data with `Garamia.PersistentStorage`, you need to install a StorageMethod. StorageMethods allow the data to be stored persistently.

Two easy StorageMethods to get started with are `Garamia.PersistentStorage.CachedJson` and `Garamia.PersistentStorage.NonCachedJson`. For this example, we will be using `Garamia.PersistentStorage.CachedJson`. So, you need to install it from the NuGet Gallery.

## Creating the root object

`Garamia.PersistentStorage` stores data in objects. These objects represented in C# are classes. For this example, we can create a class named `OBJ` and then create a field in the class named `number` where we can store a number.

```cs
class OBJ
{
    public int number { get; set; } = 0;
}
```

## Initializing and Adding the Storage Method

`Garamia.PersistentStorage` contains a list of StorageMethods which can be used to switch between different StorageMethods. But first, we need to initialize a `CachedStorageController`, which acts like a controller between this library and the Storage Method. We pass in the `OBJ` type so the controller knows which type to parse the cache as.

```cs
readonly CachedStorageController<OBJ> Storage = new CachedStorageController<OBJ>();
```

Then to add the Storage Method, we can create the StorageMethod and select it.

```cs
CachedJsonStorage<OBJ> StorageMethod = new CachedJsonStorage<OBJ>();
Storage.AddStorageMethod(StorageMethod);
Storage.SelectStorageMethod(StorageMethod);
```

Since we are storing as a JSON file, we need to pass in Properties. For this Cached Json implementation, the properties are stored as `JsonProperties`.

```cs
JSONProperties properties = new JSONProperties
{
    DataFile = "data.json",
    DataFilePath = Path.Combine("D:/", "TestApp")
};
Storage.Initialize(properties);
```

Now, our Storage Method is ready to use!

## Getting Values

Getting Values is simple. If you know there has been an update to the Json File, call the `UpdateCache` function on the controller.

```cs
Storage.UpdateCache();
```

Then, you can just get the value from the Cache.

```cs
int Number = Storage.CurrentCache.number;
```

## Setting Values

Setting Values is also simple. First, change the cache with your updated value.

```cs
int Number = 100
Storage.CurrentCache.number = Number;
```

Then, save the cache into the file with `Storage.SaveState()`. In case some outside source modified the file, it is good practice to also call `UpdateCache()` after saving. There is a shortcut method called `SaveUpdate()`.

```cs
Storage.SaveUpdate();
```
