using System.Text.Json;
using System.Text;

namespace GrpcClient.Helper
{
    public class Helper
    {
        public static HttpRequestMessage CreateHttpRequest(string requestUrl)
        {
            var httpRequest = new HttpRequestMessage();
            httpRequest.Version = new Version(1, 1);
            httpRequest.RequestUri = new Uri(requestUrl, UriKind.Relative);
            return httpRequest;
        }

        public static StringContent ConverToBodyStringContent<T>(T model)
        {
            var json = JsonSerializer.Serialize<T>(model);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
