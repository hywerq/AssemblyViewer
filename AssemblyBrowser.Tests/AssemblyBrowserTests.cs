using AssemblyBrowser.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.Reflection;

namespace AssemblyBrowser.Tests
{
    [TestClass]
    public class AssemblyBrowserTests
    {
        private ObservableCollection<Namespaces> _namespacesList;

        public int x;
        public string Name { get; set; }

        void GetAssembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            _namespacesList = new ObservableCollection<Namespaces>() { new Namespaces(assembly) };
        }
 
        [TestMethod]
        public void CountNamespaces()
        {
            GetAssembly();

            Assert.AreEqual(1, _namespacesList.Count);
            Assert.AreEqual(Assembly.GetExecutingAssembly().FullName, _namespacesList[0].Name);
        }

        [TestMethod]
        public void CountTypes()
        {
            GetAssembly();

            Assert.AreEqual(1, _namespacesList[0].TypeNodes.Count);
            Assert.AreEqual(nameof(AssemblyBrowserTests), _namespacesList[0].TypeNodes[0].Name);
        }

        [TestMethod]
        public void CountMembers()
        {
            GetAssembly();

            FieldInfo[] fields = typeof(AssemblyBrowserTests).GetFields();
            Assert.AreEqual(fields.Length, _namespacesList[0].TypeNodes[0].Members[0].Members.Count);

            PropertyInfo[] properties = typeof(AssemblyBrowserTests).GetProperties();
            Assert.AreEqual(properties.Length, _namespacesList[0].TypeNodes[0].Members[1].Members.Count);

            MethodInfo[] methods = typeof(AssemblyBrowserTests).GetMethods();
            Assert.AreEqual(methods.Length, _namespacesList[0].TypeNodes[0].Members[2].Members.Count);
        }
    }
}
