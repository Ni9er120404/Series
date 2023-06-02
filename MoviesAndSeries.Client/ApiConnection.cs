using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace MaSMAUI
{
	internal class ApiConnection
	{
		private static readonly Lazy<ApiConnection> instance = new(() => {
			var api = new ApiConnection();
			return api;
		});

		public SeriesApi Api { get; private set; }

		private ApiConnection()
		{
			Configuration configuration = new()
			{
				BasePath = "http://mas.vladexa.ru"
			};
			Api = new SeriesApi(configuration);
		}

		public static ApiConnection GetInstance()
		{
			return instance.Value;
		}
	}
}
