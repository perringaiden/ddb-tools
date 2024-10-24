using System.Text.Json;

namespace Wolflight.Communication
{
    public class HttpCommunicator
    {
        public HttpCommunicator(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        private readonly IHttpClientFactory HttpClientFactory;

        public async Task<JsonDocument> SendGetJsonRequest(
            Uri address,
            IReadOnlyDictionary<string, string> headers
        )
        {
            return await JsonDocument.ParseAsync(await SendGetRequest(address, headers));
        }

        public async Task<Stream> SendGetRequest(
            Uri address,
            IReadOnlyDictionary<string, string> headers
        )
        {

            using (HttpClient client = HttpClientFactory.CreateClient())
            {
                HttpRequestMessage request;
                HttpResponseMessage response;

                request = new HttpRequestMessage(HttpMethod.Get, address);

                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                response = await client.SendAsync(request);

                return await response.Content.ReadAsStreamAsync();
            };
        }

    }
}
