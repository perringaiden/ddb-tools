using System.Text.Json;

namespace Wolflight.DnDBeyond.Data.Processors
{
    /// <summary>
    /// An implementation to read characters from DnDBeyond.
    /// </summary>
    public class CharacterReader : ICharacterReader
    {

        /// <inheritdoc/>
        public Types.Character ReadCharacter(JsonDocument characterJson)
        {
            return null;
        }

    }
}
