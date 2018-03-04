using System.Net.Http;

namespace ListViewDemoApp.Services
{
    public static class ApiHelper
    {
        private static readonly HttpClient httpClient;

        static ApiHelper()
        {
            httpClient = new HttpClient();
        }

        public static HttpClient GetHttpClient() => httpClient;
    }
}
