using System.Collections.Generic;

namespace SmartClone
{
    /// <summary>
    ///     Represents a group of individual ites
    /// </summary>
    public class ItemGroup
    {
        public bool Hidden { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        ///     Builds a deep copy of current object
        /// </summary>
        /// <returns>Clone of current object</returns>
        public ItemGroup CopyProperties()
        {
            return Utils.DeepCopy(this);
        }
    }
}