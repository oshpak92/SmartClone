using System;
using Newtonsoft.Json;

namespace SmartClone
{
    /// <summary>
    ///     Represents a helper class that contains additional methods
    /// </summary>
    public class Utils
    {
        /// <summary>
        ///     Generic method which makes deep copy of objects
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="obj">object to clone</param>
        /// <returns>deep copy of object</returns>
        public static T DeepCopy<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Object cannot be null");

            var stryngifiedObject = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(stryngifiedObject);
        }
    }
}