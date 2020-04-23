using System;
using System.Collections.Generic;
using System.Text;

namespace PersistentStorage
{
    /// <summary>
    /// The base for a Storage Method
    /// </summary>
    public interface IStorageMethod<T>
    {
        /// <summary>
        /// The name of the Storage Method
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Initializes the Storage Method
        /// </summary>
        void Initialize();
    }
}
