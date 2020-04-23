using System;
using System.Collections.Generic;
using System.Text;

namespace PersistentStorage
{
    /// <summary>
    /// The Base for a Cached Persistent Storage File
    /// </summary>
    public interface ICachedStorageMethodFile<T> : ICachedStorageMethod<T>
    {
        /// <summary>
        /// The file containing the data
        /// </summary>
        string DataFile { get; set; }
        /// <summary>
        /// Initializes the Storage Method
        /// </summary>
        /// <param name="DataFile">The path to the file</param>
        void Initialize(string DataFile);
    }
}
