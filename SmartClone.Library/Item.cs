namespace SmartClone
{
    /// <summary>
    ///     Represents the individual item
    /// </summary>
    public class Item
    {
        public bool Hidden { get; set; }
        public bool Maximized { get; set; }

        /// <summary>
        ///     Builds a deep copy of current object
        /// </summary>
        /// <returns></returns>
        public Item CopyProperties()
        {
            return Utils.DeepCopy(this);
        }
    }
}