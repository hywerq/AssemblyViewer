namespace AssemblyBrowser.Components
{
    public class Methods : IMember
    {
        public string Item { get { return Name + Parameters; } }

        internal string Name { get; set; }
        internal string Parameters { get; set; }
    }
}
