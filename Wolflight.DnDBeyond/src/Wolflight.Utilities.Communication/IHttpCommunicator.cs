using System.Text.Json;

namespace Wolflight.Communication
{
    /// <summary>
    /// An interface for making HTTP requests.
    /// </summary>
    public interface IHttpCommunicator
    {
        /// <summary>
        /// Make a GET request that returns a <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="address">The address to make the GET request to.</param>
        /// <param name="headers">The headers to the request.</param>
        /// <returns>The data if successful.</returns>
        Task<JsonDocument> SendGetJsonRequest(Uri address, IReadOnlyDictionary<string, string> headers);

        /// <summary>
        /// Make a GET request that returns a <see cref="Stream"/>.
        /// </summary>
        /// <param name="address">The address to make the GET request to.</param>
        /// <param name="headers">The headers to the request.</param>
        /// <returns></returns>
        Task<Stream> SendGetRequest(Uri address, IReadOnlyDictionary<string, string> headers);
    }
}