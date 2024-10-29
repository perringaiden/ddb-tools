using System.Text.Json;
using Wolflight.DnDBeyond.Data.Json.Character;

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
            Types.Character rc = new();

            Json.JsonCharacter? jsonCharacter;

            jsonCharacter = JsonSerializer.Deserialize<Json.JsonCharacter>(characterJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!(jsonCharacter?.Data?.Stats == null))
            {
                foreach (Stat attribute in jsonCharacter.Data.Stats)
                {
                    switch (attribute.ID)
                    {
                        case AttributeTypes.Strength:
                            rc.Attributes.Strength.BaseValue = attribute.Value;
                            break;
                    }
                }

            }

            return rc;
        }

    }
}
