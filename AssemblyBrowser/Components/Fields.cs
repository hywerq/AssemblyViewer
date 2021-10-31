namespace AssemblyBrowser.Components
{
    public class Fields : IMember
    {
        public string Item { get { return FieldType + " " + Name; } }

        internal string Name { get; set; }
        internal string FieldType { get; set; }
    }
}
