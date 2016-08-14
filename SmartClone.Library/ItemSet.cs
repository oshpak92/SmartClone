using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartClone
{
    /// <summary>
    /// Represents a high level container.
    /// Has header item.
    /// Has list of groups
    /// </summary>
    public class ItemSet
    {
        public Item Header { get; set; }
        public List<ItemGroup> Groups { get; set; } = new List<ItemGroup>();

        /// <summary>
        /// Builds a smart copy of current object
        /// </summary>
        /// <returns>cloned object</returns>
        public ItemSet SmartClone()
        {
            if (Header == null)
                throw new NullReferenceException("Header property can’t be null");
            
            var clonedSet = this.CopyProperties();

            if (Header.Maximized)
            {
                clonedSet.Groups = new List<ItemGroup>();
                return clonedSet;
            }

            //get visible groups
            clonedSet.Groups = Groups.Where(group => !group.Hidden).ToList();

            //filter items by "Hidden" and "Maximized" rules
            foreach (var group in clonedSet.Groups)
            {
                var maximizedItem = group.Items.FirstOrDefault(item => item.Maximized && !item.Hidden);

                group.Items = maximizedItem != null
                    ? new List<Item> {maximizedItem}
                    : group.Items.Where(item => !item.Hidden).ToList();
            }

            return clonedSet;
        }

        /// <summary>
        /// Makes deep copy of current object
        /// </summary>
        /// <returns>cloned object</returns>
        public ItemSet CopyProperties()
        {
            return Utils.DeepCopy(this);
        }
    }
}