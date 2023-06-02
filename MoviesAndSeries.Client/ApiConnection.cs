using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;

namespace MaSMAUI
{
    internal class ApiConnection
    {
        private static readonly Lazy<ApiConnection> instance = new(() =>
        {
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
