namespace PersistentStorage
{
    /// <summary>
    /// The base for a Cached Storage Method File
    /// </summary>
    /// <typeparam name="T">The Base Object</typeparam>
    public interface ICachedStorageMethodFile<T> : ICachedStorageMethod<T>
    {
        /// <summary>
        /// The file containing the data
        /// </summary>
        string DataFile { get; set; }
    }
}
