using System.Text.Json;

namespace Wolflight.Utilities.Communication
{
    public class HttpCommunicator : IHttpCommunicator
    {
        /// <summary>
        /// Creates a new instance of a <see cref="HttpCommunicator"/>.
        /// </summary>
        /// <param name="httpClientFactory">The factory to generate <see cref="HttpClient"/> items.</param>
        public HttpCommunicator(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// The factory to generate <see cref="HttpClient"/> items.
        /// </summary>
        private readonly IHttpClientFactory HttpClientFactory;

        /// <inheritdoc/>
        public async Task<JsonDocument> SendGetJsonRequest(
            Uri address,
            IReadOnlyDictionary<string, string> headers
        )
        {
            return await JsonDocument.ParseAsync(await SendGetRequest(address, headers));
        }

        /// <inheritdoc/>
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
