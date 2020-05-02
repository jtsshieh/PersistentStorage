using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistentStorage.Queried
{

    /// <summary>
    /// A parser to parse queries
    /// </summary>
    public static class QueryParser
    {
        /// <summary>
        /// Parse a query and then get/add/insert an item
        /// </summary>
        /// <typeparam name="T">The type to parse the result as/the type of the value being set</typeparam>
        /// <param name="query">The query</param>
        /// <param name="rootObject">The object to search/preform the operation on</param>
        /// <param name="value">The value to set</param>
        /// <param name="index">The index if adding to an array -- -1 for no array, -2 for pushing to an array.</param>
        /// <returns></returns>
        static object ParseQuery<T>(string query, object rootObject, T value = default, int index = -1)
        {
            // Split the query into parts
            List<string> QueryParts = new List<string>(query.Split('.'));

            // Set the current working object to the root object
            object CurrentObject = rootObject;

            // Start an index counter
            int CurrentIndex = 1;

            // Loop through the query parts
            foreach (string QueryPart in QueryParts)
            {
                // Get the type of the Current working object
                Type type = CurrentObject.GetType();

                // Check if we are parsing an array
                if (QueryPart.Contains("["))
                {
                    // Split the array string into 3 parts, array name, array number, blank
                    List<string> ArrayParts = new List<string>(QueryPart.Split('[', ']'));

                    // Cast the array into an IEnumerable
                    IEnumerable Array = (IEnumerable)type.GetField(ArrayParts[0]).GetValue(CurrentObject);

                    // Check if we are setting information
                    if ((CurrentIndex == QueryParts.Count) && (!EqualityComparer<T>.Default.Equals(default, value)))
                    {
                        // Turn the IEnumerable to a list
                        List<T> List = Array.OfType<T>().ToList();

                        // Set the value in the list
                        List[int.Parse(ArrayParts[1])] = value;

                        // Put this list into the object
                        type.GetField(ArrayParts[0]).SetValue(CurrentObject, List);

                        // Return the object with the update
                        return rootObject;
                    }
                    
                    // Set the current working object to the value in the array
                    CurrentObject = Array.OfType<object>().ToList()[int.Parse(ArrayParts[1])];

                }
                // We are parsing an object
                else
                {
                    // Get information about the field
                    System.Reflection.FieldInfo fieldinfo = type.GetField(QueryPart);

                    // Check if we are setting information or adding to an array
                    if (CurrentIndex == QueryParts.Count)
                    {

                        // Check if we are adding to an array
                        if (index != -1)
                        {
                            List<T> List = (List<T>)fieldinfo.GetValue(CurrentObject);

                            // Check if we are pushing to an array
                            if (index == -2)
                            {
                                // Push to the array
                                List.Add(value);
                            }
                            // Check if we are inserting to the array
                            else
                            {
                                // Insert to the array
                                List.Insert(index, value);
                            }

                            // Update the array in the object
                            fieldinfo.SetValue(CurrentObject, List);
                            
                            // Return the object with the update
                            return rootObject;
                        }
                        else if (!EqualityComparer<T>.Default.Equals(default, value))
                        {
                            // Set the field value
                            fieldinfo.SetValue(CurrentObject, value);

                            // Return the object with the update
                            return rootObject;
                        }
                    }

                    // Set the current working object ot the value in the field
                    CurrentObject = fieldinfo.GetValue(CurrentObject);
                }
                CurrentIndex++;
            }

            // If we are not setting an object, return the current working object
            return CurrentObject;
        }


        /// <summary>
        /// Get a value that is filtered using a query
        /// </summary>
        /// <typeparam name="T">The type to parse the result as</typeparam>
        /// <param name="query">The query</param>
        /// <param name="rootObject">The object to search for the result in</param>
        /// <returns>The value the query yielded, parsed the type specified in T</returns>
        public static T GetValue<T>(string query, object rootObject)
        {
            return (T)ParseQuery(query, rootObject, Activator.CreateInstance<T>());
        }

        /// <summary>
        /// Set a value that is filtered using a query
        /// </summary>
        /// <typeparam name="T">The type of the value that is being set</typeparam>
        /// <param name="query">The query</param>
        /// <param name="rootObject">The object to set the value on</param>
        /// <param name="value">The value to set</param>
        /// <returns>The object with the value set</returns>
        public static object SetValue<T>(string query, object rootObject, T value)
        {
            return ParseQuery(query, rootObject, value);
        }

        /// <summary>
        /// Inserts an item into an array
        /// </summary>
        /// <typeparam name="T">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="rootObject">The object to set the value on</param>
        /// <param name="item">The item being inserted into the array</param>
        /// <param name="index">The index to insert the item into</param>
        /// <returns>The object with the item inserted</returns>
        public static object InsertArray<T>(string query, object rootObject, T item, int index)
        {
            return ParseQuery(query, rootObject, item, index);
        }

        /// <summary>
        /// Push an item into an array
        /// </summary>
        /// <typeparam name="T">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="rootObject">The object to set the value on</param>
        /// <param name="item">The item being pushed into the array</param>
        /// <returns>The object with the item pushed</returns>
        public static object PushArray<T>(string query, object rootObject, T item)
        {
            return ParseQuery(query, rootObject, item, -2);
        }

        /// <summary>
        /// Remove an item from an array by its index
        /// </summary>
        /// <typeparam name="T">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="rootObject">The object to set the value on</param>
        /// <param name="index">The index of the item that needs to be removed</param>
        /// <returns>The object with the item removed</returns>
        public static object RemoveAtArray<T>(string query, object rootObject, int index)
        {
            List<T> List = GetValue<List<T>>(query, rootObject);
            List.RemoveAt(index);
            return SetValue(query, rootObject, List);
        }

        /// <summary>
        /// Remove an item from an array
        /// </summary>
        /// <typeparam name="T">The type of the value being set</typeparam>
        /// <param name="query">The query selecting an array</param>
        /// <param name="rootObject">The object ot set the value on</param>
        /// <param name="item">The item that needs to be removed</param>
        /// <returns>The object with the item removed</returns>
        public static object RemoveArray<T>(string query, object rootObject, T item)
        {
            List<T> List = GetValue<List<T>>(query, rootObject);
            List.Remove(item);
            return SetValue(query, rootObject, List);
        }

    }
}
