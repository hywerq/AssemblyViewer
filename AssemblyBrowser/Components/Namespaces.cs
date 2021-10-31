using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace AssemblyBrowser.Components
{
    public class Namespaces : ViewModelBase
    {
        private Assembly _assembly;

        public string Name { get { return _assembly.FullName; } }
        public ObservableCollection<Types> TypeNodes { get { return new ObservableCollection<Types>(GetTypesInAssembly()); } }

        public Namespaces(Assembly assembly)
        {
            _assembly = assembly;
        }

        private ObservableCollection<Types> GetTypesInAssembly()
        {
            Type[] types = _assembly.GetTypes();
            ObservableCollection<Types> typesList = new ObservableCollection<Types>();

            foreach (Type type in types)
            {
                typesList.Add(new Types(type) { Name = type.Name });
            }

            return typesList;
        }
    }
}
