using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace RentalModel.Repository.Tools.Testing
{
    internal class Test
    {

        public List<string> excludedclasses = new List<string>
        {
            "RentalModel.Context",
            "RentalModel.Designer",
            "RentalModel.edmx.diagram",
            "sysdiagram",
            "RentalModel",
            "RentalContext"
        };



        public IEnumerable<Type> GetAllClasses()
        {
            var classTypes = new List<Type>();
            var assembly =
                Assembly.LoadFile(
                    @"C:\Users\haraissia\Desktop\Latest\RentalMobile\RentalMobile.Model\bin\Debug\RentalMobile.Model.dll");

            foreach (
                Type type in assembly.GetTypes().Where(x => x.IsClass && x.Namespace == "RentalMobile.Model.Models"))
            {
                if (!excludedclasses.Contains(type.Name))
                {
                    classTypes.Add(type);
                }

            }
            return classTypes;

        }
    }
}
