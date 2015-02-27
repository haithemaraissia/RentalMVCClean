using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace RentalModel.Repository.Tools.Testing
{
    public class Test
    {
        Test()
        {



            var mylist = new List<string>();
            DirectoryInfo dinfo = new DirectoryInfo(@"C:\TestDirectory");
            FileInfo[] Files = dinfo.GetFiles("*.cs");
            foreach (var file in Files)
            {

                mylist.Add(file.Name);
            }
        }


        private List<string> GetAllFiles()
        {
            DirectoryInfo dinfo = new DirectoryInfo("@C:/Direcotry");
            List<string> files = (dinfo.GetFiles("*.cs").Select(fileName => Path.GetFileNameWithoutExtension(fileName.ToString()))).ToList();

            var excludedclasses =
                new List<string>
                {
                    "RentalContextGenerator.Context1",
                    "RentalContextGenerator",
                    "RentalContextGenerator1",
                    "RentalModel.Designer",
                    "RentalModel1.Designer",
                    "sysdiagram"
                };
            var mylist = files.Except(excludedclasses);
            return mylist.ToList();
        }

        public IEnumerable<Type> test()
        {

            List<Type> s = new List<Type>();
            Assembly assembly = Assembly.LoadFile(@"C:\Users\haraissia\Desktop\Latest\RentalMobile\RentalMobile.Model\bin\Debug\RentalMobile.Model.dll");

            foreach (Type ti in assembly.GetTypes().Where(x => x.IsClass).Where(type => type.Namespace == "RentalMobile.Model.ModelViews"))
            {
                s.Add(ti);
            }

            return s;


            //foreach (Type ti in assembly.GetTypes().Where(x => x.IsClass).Where(type => type.Namespace == "RentalMobile.Model.ModelViews"))
            //{

            //}

            //var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            //        where t.IsClass && t.Namespace == RentalMobile.Model.ModelViews
            //        select t;
            //q.ToList().ForEach(t => Console.WriteLine(t.Name));
        }


        public IEnumerable<Type> GetAllClasses()
        {

            var classTypes = new List<Type>();
            var assembly = Assembly.LoadFile(@"C:\Users\haraissia\Desktop\Latest\RentalMobile\RentalMobile.Model\bin\Debug\RentalMobile.Model.dll");

            foreach (Type type in assembly.GetTypes().Where(x => x.IsClass && x.Namespace == "RentalMobile.Model.ModelViews"))
            {
                classTypes.Add(type);
            }

            return classTypes;
        }


        public Dictionary<string, string> GetAllFiledOfEachClass()
        {
            Dictionary<string,string> fieldDictionary = new Dictionary<string, string>();
            foreach (var classType in GetAllClasses())
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
            foreach (var classType in GetAllClasses())
            {
                MemberInfo[] mi =  classType.GetMembers();

                foreach (MemberInfo member in mi)
                {
                    memberDictionary.Add(member.Name, member.GetType().ToString());
                }
            }

            return memberDictionary;
        }


        public void GetProperties()
        {
             Dictionary<string,string> PropertyDictionary = new Dictionary<string, string>();
            foreach (var classType in GetAllClasses())
            {
                foreach (var prop in classType.GetType().GetProperties())
                {
                    Console.WriteLine("{0}={1}", prop.Name, prop.PropertyType);
                }
            }
        }

        public void WriteAllClassesName()
        {
            foreach (Type classType in GetAllClasses())
            {
                Console.Write(classType.Name);
            }
        }


        public void WriteAllFields()
        {
            foreach (Type classType in GetAllClasses())
            {
                    FieldInfo[] fi = classType.GetFields();
                    foreach (FieldInfo field in fi)
                    {
                        Console.Write(field.Name, field.FieldType);
                    }
                }
            }


        }
    }

