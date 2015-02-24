using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using  System.Xml;

namespace RentalMobile.Model.Tools
{
    public class Test
    {
        Test()
        {
            
       
        var mylist = new List<string>();
        DirectoryInfo dinfo = new DirectoryInfo(@"C:\TestDirectory");
        FileInfo[] Files = dinfo.GetFiles("*.cs");
        foreach( var file in Files)
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
            var mylist  = files.Except(excludedclasses);
            return mylist.ToList();
        }
    }
}
