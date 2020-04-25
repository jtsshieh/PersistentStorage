namespace PersistentStorage
{
    /// <summary>
    /// The base for a storage method
    /// </summary>
    /// <typeparam name="T">The object being stored</typeparam>
    public interface IStorageMethod<T>
    {
        /// <summary>
        /// The name of the storage method
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Initializes the storage method
        /// </summary>
        void Initialize();
    }
}
