using System.Text.Json;

namespace Wolflight.DMScreen.Character.Processors
{
    /// <summary>
    /// An interface for reading characters.
    /// </summary>
    public interface ICharacterReader
    {
        /// <summary>
        /// Reads a <see cref="JsonDocument"/> from DnDBeyond's character API into a <see cref="Types.Character"/>.
        /// </summary>
        /// <param name="characterJson">The character JSON to read.</param>
        /// <returns>The processed <see cref="Types.Character"/>.</returns>
        Types.CharacterSheet ReadCharacter(JsonDocument characterJson);

    }
}
