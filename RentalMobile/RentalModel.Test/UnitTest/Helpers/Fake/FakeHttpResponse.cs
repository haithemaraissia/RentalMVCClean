using System;
using System.Collections.Specialized;
using System.Web;

namespace TestProject.UnitTest.Helpers.Fake
{
	public class FakeHttpResponse : HttpResponseBase
	{
		public override void End()
		{
			
		}

		public override int StatusCode
		{
			get;
			set;
		}

		public override void Clear()
		{
			StatusCode = 0;
		}

		public override void AddHeader(string name, string value)
		{
			this.Headers[name] = value;
		}

		public override string ApplyAppPathModifier(string virtualPath)
		{
			return virtualPath;
		}

		private NameValueCollection _headers = new NameValueCollection();
		public override NameValueCollection Headers
		{
			get
			{
				return _headers;
			}
		}

		private HttpCookieCollection _cookies = new HttpCookieCollection();
		public override HttpCookieCollection Cookies
		{
			get
			{
				return _cookies;
			}
		}

		public override HttpCachePolicyBase Cache
		{
			get
			{
				return new FakeHttpCachePolicy();
			}
		}

		public override string ContentType
		{
			get
			{
				return "text/dummy";
			}
			set
			{
				
			}
		}
	}

	public class FakeHttpCachePolicy : HttpCachePolicyBase
	{
		public FakeHttpCachePolicy()
			: base()
		{

		}

		public override void SetMaxAge(TimeSpan delta)
		{
			
		}

		public override void SetProxyMaxAge(TimeSpan delta)
		{
			
		}

		public override void AddValidationCallback(HttpCacheValidateHandler handler, object data)
		{
			
		}
	}
}
