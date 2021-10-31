namespace AssemblyBrowser.Components
{
    public class Properties : IMember
    {
        public string Item { get { return PropertyType + " "+ Name; } }

        internal string Name { get; set; }
        internal string PropertyType { get; set; }
    }
}
