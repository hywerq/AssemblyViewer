using System.Collections.ObjectModel;

namespace AssemblyBrowser.Components
{
    public class MemberContainer
    {
        public ObservableCollection<IMember> Members { get; set; }

        public string Name { get; set; }

        public MemberContainer(string name, ObservableCollection<IMember> members)
        {
            Name = name;
            Members = members;
        }
    }
}
