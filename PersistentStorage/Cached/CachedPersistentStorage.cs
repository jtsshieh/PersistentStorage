using System;
using System.Collections.Generic;

namespace PersistentStorage
{
    public class CachedPersistentStorage<T> : PersistentStorage<T>
    {
        public T CurrentCache;

        public bool Initialize()
        {
            if (StorageMethod == null) return false;
            StorageMethod.Initialize();
            ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
            CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
            return true;
        }

        public bool Initialize(string DataFile)
        {
            if (StorageMethod == null) return false;
            if (StorageMethod is ICachedStorageMethodFile<T>)
            {
                ((ICachedStorageMethodFile<T>)StorageMethod).Initialize(DataFile);
                ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
                CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
                return true;
            }
            return false;
        }

        public void SaveState()
        {
            ((ICachedStorageMethod<T>)StorageMethod).SetCache(CurrentCache);
            ((ICachedStorageMethod<T>)StorageMethod).SaveState();
        }

        public void UpdateCache()
        {
            ((ICachedStorageMethod<T>)StorageMethod).UpdateCache();
            CurrentCache = ((ICachedStorageMethod<T>)StorageMethod).GetCache();
        }

        public void SaveUpdate()
        {
            SaveState();
            UpdateCache();
        }
    }
}
