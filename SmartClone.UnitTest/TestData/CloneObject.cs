namespace SmartClone.UnitTest.TestData
{
    /// <summary>
    ///     Represents simple object only for testing Deep copy functionnality
    /// </summary>
    public class CloneObject
    {
        public string Name { get; set; } = string.Empty;
        public CloneObject ChildObject { get; set; }
    }
}