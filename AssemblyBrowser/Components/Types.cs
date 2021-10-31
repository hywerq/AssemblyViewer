using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace AssemblyBrowser.Components
{
    public class Types
    {
        private Type _type;

        public ObservableCollection<MemberContainer> Members { get; set; }
        public string Name { get; set; }

        public Types(Type type)
        {
            _type = type;
            Members = new ObservableCollection<MemberContainer>
            {
                new MemberContainer("Fields", GetFields()),
                new MemberContainer("Properties", GetProperties()),
                new MemberContainer("Methods", GetMethods())
            };
        }

        private ObservableCollection<IMember> GetFields()
        {
            FieldInfo[] fields = _type.GetFields();
            ObservableCollection<IMember> fieldsList = new ObservableCollection<IMember>();

            foreach (FieldInfo fieldInfo in fields)
            {
                fieldsList.Add(new Fields { Name = fieldInfo.FieldType + " " + fieldInfo.Name });
            }

            return fieldsList;
        }

        private ObservableCollection<IMember> GetProperties()
        {
            PropertyInfo[] properties = _type.GetProperties();
            ObservableCollection<IMember> propertiesList = new ObservableCollection<IMember>();

            foreach (PropertyInfo propertyInfo in properties)
            {
                propertiesList.Add(new Properties { PropertyType = propertyInfo.PropertyType.ToString(), Name = propertyInfo.Name });
            }

            return propertiesList;
        }

        private ObservableCollection<IMember> GetMethods()
        {
            MethodInfo[] methods = _type.GetMethods();
            ObservableCollection<IMember> methodsList = new ObservableCollection<IMember>();

            string methodParameters = "";

            foreach (MethodInfo methodInfo in methods)
            {
                foreach (ParameterInfo parameter in methodInfo.GetParameters())
                {
                    methodParameters += parameter.ParameterType + " " + parameter.Name + ", ";
                }

                if (methodParameters.Length > 0)
                    methodParameters = methodParameters.Substring(0, methodParameters.Length - 2);

                methodsList.Add(new Methods { Name = methodInfo.Name, Parameters = "(" + methodParameters + ")" });
            }

            return methodsList;
        }
    }
}
