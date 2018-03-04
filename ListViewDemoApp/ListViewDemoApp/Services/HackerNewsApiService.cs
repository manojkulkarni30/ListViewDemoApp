using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ListViewDemoApp.Services
{
    public class HackerNewsApiService
    {
        #region Fields

        private readonly HttpClient _httpClient;
        private readonly JsonSerializer _serializer;

        #endregion

        #region Constructor

        public HackerNewsApiService()
        {
            _httpClient = ApiHelper.GetHttpClient();
            _serializer = new JsonSerializer();
        }

        #endregion

        #region Methods

        public async Task<T> GetDataAsync<T>(string apiurl) where T : class
        {
            try
            {
                var response = await _httpClient.GetAsync(apiurl).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content
                    .ReadAsStreamAsync().ConfigureAwait(false))
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    return _serializer.Deserialize<T>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }

        #endregion
    }
}
