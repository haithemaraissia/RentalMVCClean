using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentalMobile.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            //var TypePropertiersExtraction = new TypePropertiersExtraction();
            //List<object> objects = new List<object>();
            //foreach (Type type in TypePropertiersExtraction.AllClasses)
            //{
            //    objects.Add(Activator.CreateInstance(type));
            //}




            //Type testType = typeof(TestClass);
            //ConstructorInfo ctor = testType.GetConstructor(System.Type.EmptyTypes);
            //if (ctor != null)
            //{
            //    object instance = ctor.Invoke(null);
            //    MethodInfo methodInfo = testType.GetMethod("TestMethod");
            //    System.Console.WriteLine(methodInfo.Invoke(instance, new object[] { 10 }));
            //}
            //System.Console.ReadKey();

            var TypePropertiersExtraction = new TypePropertiersExtraction();

        }
    }

    public class TestClass
    {
        private int testValue = 42;

        public int TestMethod(int numberToAdd)
        {
            return this.testValue + numberToAdd;
        }


    }
}
