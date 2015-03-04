using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentalMobile.Console
{
    public class TypePropertiersExtraction
    {
        public TypePropertiersExtraction()
        {
            
        }

        public IEnumerable<Type> AllClasses
        {
            get
            {
                var classTypes = new List<Type>();
                var assembly =
                    Assembly.LoadFile(
                        @"C:\Users\haraissia\Desktop\Latest\RentalMobile\RentalMobile.Model\bin\Debug\RentalMobile.Model.dll");

                foreach (
                    Type type in assembly.GetTypes().Where(x => x.IsClass && x.Namespace == "RentalMobile.Model.ModelViews"))
                {
                    classTypes.Add(type);
                }
                return classTypes;
            }
        }

        public IEnumerable<Type> GetTypesFromNamespace(Assembly assembly, String desiredNamespace)
        {
            return assembly.GetTypes()
                .Where(type => type.Namespace == desiredNamespace);
        }


        public Dictionary<string, string> GetAllFiledOfEachClass()
        {
            Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
            foreach (var classType in AllClasses)
            {
                FieldInfo[] fi = classType.GetFields();

                foreach (FieldInfo field in fi)
                {
                    fieldDictionary.Add(field.Name, field.FieldType.ToString());
                }
            }

            return fieldDictionary;
        }

        public Dictionary<string, string> GetAllMemebersForEachClass()
        {
            var memberDictionary = new Dictionary<string, string>();
            foreach (var classType in AllClasses)
            {
                MemberInfo[] mi = classType.GetMembers();

                foreach (MemberInfo member in mi)
                {
                    memberDictionary.Add(member.Name, member.GetType().ToString());
                }
            }

            return memberDictionary;
        }

        public void GetProperties()
        {
            Dictionary<string, string> PropertyDictionary = new Dictionary<string, string>();
            foreach (var classType in AllClasses)
            {
                foreach (var prop in classType.GetType().GetProperties())
                {
                    //WriteLine("{0}={1}", prop.Name, prop.GetValue(classType, null));
                }
            }
        }




        public void GetPrimitiveProperty(Type classType)
        {
            while (classType.IsPrimitive == false)
            {
                var properties = classType.GetProperties();

                foreach (PropertyInfo pi in properties)
                {
                    //Write("Name ");
                    //Write(pi.Name);
                    //Write("  ");
                    //Write("Property ");
                    //Write(pi.PropertyType.ToString());
                    //Write("  ");

                    if (pi.PropertyType.IsPrimitive)
                    {
                        //Write("Primitive Type ");
                        //Write(pi.PropertyType.ToString());
                        //Write("  ");
                        //Write("Testing ");
                        //Write(pi.Name);
                        //Write(" = new ");
                        //Write(pi.PropertyType.ToString());
                        //Write(" ();");
                    }
                    else
                    {
                        //Write("User Defined Type ");
                        //Write(pi.PropertyType.ToString());
                        //// GetPrimitiveProperty(pi.PropertyType);
                        //Write("This should be another iteration");
                        //Write("  ");
                    }
                }
            }
        }  


    }
}
