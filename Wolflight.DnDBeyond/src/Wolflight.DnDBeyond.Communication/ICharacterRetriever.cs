using System.Text.Json;

namespace Wolflight.DnDBeyond.Communication
{
    /// <summary>
    /// Provides methods for retrieving character data.
    /// </summary>
    public interface ICharacterRetriever
    {

        /// <summary>
        /// Retrieves an accessible character by ID.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <param name="token">The authorization token to use.</param>
        /// <returns>The raw character JSON.</returns>
        Task<JsonDocument> Retrieve(long id, string? token);
    }
}