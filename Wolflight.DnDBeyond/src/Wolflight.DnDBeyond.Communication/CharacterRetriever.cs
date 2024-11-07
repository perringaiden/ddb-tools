using System.Text.Json;

namespace Wolflight.DnDBeyond.Communication
{
    public class CharacterRetriever(Utilities.Communication.IHttpCommunicator communicator) : ICharacterRetriever
    {

        /// <summary>
        /// The web address for the character.
        /// </summary>
        private const string CharacterFormat = "https://character-service.dndbeyond.com/character/v5/character/{0}?includeCustomItems=true";


        /// <summary>
        /// The HTTP Communicator to use.
        /// </summary>
        private Utilities.Communication.IHttpCommunicator Communicator { get; } = communicator;

        /// <inheritdoc/>
        public async Task<JsonDocument> Retrieve(long id, string? token)
        {
            Dictionary<string, string> headers = new();

            if (!string.IsNullOrEmpty(token))
            {
                headers["Authorization"] = $"Bearer {token}";
            }

            return await Communicator.SendGetJsonRequest(new Uri(string.Format(CharacterFormat, id)), headers);

        }
    }
}

