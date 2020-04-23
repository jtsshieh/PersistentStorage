using System;
using System.Collections.Generic;
using System.Text;

namespace PersistentStorage
{
    public class PersistentStorage<T>
    {
        public List<IStorageMethod<T>> StorageMethods = new List<IStorageMethod<T>>();
        public IStorageMethod<T> StorageMethod;

        public PersistentStorage(params IStorageMethod<T>[] StorageMethods)
        {
            this.StorageMethods.AddRange(StorageMethods);
        }

        public void AddStorageMethod(ICachedStorageMethod<T> StorageMethod)
        {
            StorageMethods.Add(StorageMethod);
        }

        public void SelectStorageMethod(ICachedStorageMethod<T> StorageMethod)
        {
            if (StorageMethods.Contains(StorageMethod)) this.StorageMethod = StorageMethod;
        }
    }
}
