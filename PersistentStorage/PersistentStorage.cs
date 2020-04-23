using System.Collections.Generic;

namespace PersistentStorage
{
    /// <summary>
    /// Base Persistent Storage Class
    /// </summary>
    /// <typeparam name="T">The Base Object</typeparam>
    public class PersistentStorage<T>
    {
        /// <summary>
        /// List of Storage Methods
        /// </summary>
        public List<IStorageMethod<T>> StorageMethods = new List<IStorageMethod<T>>();

        /// <summary>
        /// The Selected Storage Method
        /// </summary>
        public IStorageMethod<T> StorageMethod;

        /// <summary>
        /// Initialize a new Persistent Storage
        /// </summary>
        /// <param name="StorageMethods">An array of storage methods to add</param>
        public PersistentStorage(params IStorageMethod<T>[] StorageMethods)
        {
            this.StorageMethods.AddRange(StorageMethods);
        }

        /// <summary>
        /// Add a Storage Method
        /// </summary>
        /// <param name="StorageMethod">The Storage Method to add</param>
        public void AddStorageMethod(IStorageMethod<T> StorageMethod)
        {
            StorageMethods.Add(StorageMethod);
        }

        /// <summary>
        /// Selects a Storage Method by its instance, if it exists
        /// </summary>
        /// <param name="StorageMethod">The Storage Method instance to select</param>
        public void SelectStorageMethod(IStorageMethod<T> StorageMethod)
        {
            if (StorageMethods.Contains(StorageMethod)) this.StorageMethod = StorageMethod;
        }

        /// <summary>
        /// Selects a Storage Method by its name, if it exists
        /// </summary>
        /// <param name="StorageMethodName">The Name of the Storage Method to select</param>
        public void SelectStorageMethod(string StorageMethodName)
        {
            foreach(IStorageMethod<T> StorageMethod in StorageMethods)
            {
                if(StorageMethod.Name == StorageMethodName)
                {
                    this.StorageMethod = StorageMethod;
                }
            }
        }
    }
}
