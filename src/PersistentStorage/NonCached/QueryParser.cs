using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistentStorage.NonCached
{
    public static class QueryParser
    {
        public static T GetValue<T>(string query, object rootObject)
        {
            List<string> QueryParts = new List<string>(query.Split('.'));
            object CurrentObject = rootObject;

            foreach(string QueryPart in QueryParts)
            {
                Type type = CurrentObject.GetType();

                if (QueryPart.Contains("["))
                {
                    List<string> ArrayParts = new List<string>(QueryPart.Split('[', ']'));
                    IEnumerable Array = (IEnumerable)type.GetField(ArrayParts[0]).GetValue(CurrentObject);
                    
                    CurrentObject = Array.OfType<object>().ToList()[int.Parse(ArrayParts[1])];

                }
                else
                {
                    System.Reflection.FieldInfo fieldinfo = type.GetField(QueryPart);
                    CurrentObject = fieldinfo.GetValue(CurrentObject);
                }
            }
            return (T)CurrentObject;
        }

        
        public static object SetValue<T>(string query, object rootObject, T value)
        {
            List<string> QueryParts = new List<string>(query.Split('.'));
            object CurrentObject = rootObject;

            int CurrentIndex = 1;
            foreach (string QueryPart in QueryParts)
            {
                Type type = CurrentObject.GetType();

                if (QueryPart.Contains("["))
                {
                    List<string> ArrayParts = new List<string>(QueryPart.Split('[', ']'));
                    IEnumerable Array = (IEnumerable)type.GetField(ArrayParts[0]).GetValue(CurrentObject);
                    if (CurrentIndex == QueryParts.Count)
                    {
                        List<T> List = Array.OfType<T>().ToList();
                        List[int.Parse(ArrayParts[1])] = value;
                        type.GetField(ArrayParts[0]).SetValue(CurrentObject, List);
                        return rootObject;
                    }
                    CurrentObject = Array.OfType<object>().ToList()[int.Parse(ArrayParts[1])];

                }
                else
                {
                    System.Reflection.FieldInfo fieldinfo = type.GetField(QueryPart);
                    if(CurrentIndex == QueryParts.Count)
                    {
                        fieldinfo.SetValue(CurrentObject, value);
                        return rootObject;
                    }
                    CurrentObject = fieldinfo.GetValue(CurrentObject);
                }
                CurrentIndex++;
            }
            return null;
        }
    

    }
}
