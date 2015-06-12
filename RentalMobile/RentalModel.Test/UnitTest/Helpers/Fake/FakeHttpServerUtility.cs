using System.Configuration;
using System.IO;
using System.Web;

namespace TestProject.UnitTest.Helpers.Fake
{
	public class FakeHttpServerUtility : HttpServerUtilityBase
	{
		private string _applicationRootConfigurationPath;

		public FakeHttpServerUtility()
			: base()
		{

		}

		public override string MachineName
		{
			get
			{
				return "Fake-MachineName";
			}
		}

		public override int ScriptTimeout
		{
			get
			{
				return 1000;
			}
			set
			{
				
			}
		}


		//Assign a base path at appSettings (key=FakeApplicationRoot) of the app.config file
		public override string MapPath(string path)
		{
			if (_applicationRootConfigurationPath == null)
			{
				string localConfig = ConfigurationManager.AppSettings["FakeApplicationRoot"];
				localConfig = localConfig == null ? "" : localConfig;
				System.Configuration.Configuration applicationConfiguration = ConfigurationManager.OpenExeConfiguration("");
				_applicationRootConfigurationPath = Path.Combine(Path.GetDirectoryName(applicationConfiguration.FilePath), localConfig);
			}
			if (path.StartsWith("~/"))
			{
				path = path.Substring(2);
			}
			else if (path.StartsWith("/"))
			{
				path = path.Substring(1);
			}
			path = path.Replace("/", "\\");

			return Path.Combine(_applicationRootConfigurationPath, path);
		}
	}
}
