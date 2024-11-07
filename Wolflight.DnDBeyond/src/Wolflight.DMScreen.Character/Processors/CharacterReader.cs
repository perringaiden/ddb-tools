using System.Text.Json;
using Wolflight.DnDBeyond.Data.Json;
using Wolflight.DnDBeyond.Data.Json.Character;

namespace Wolflight.DMScreen.Character.Processors
{
    /// <summary>
    /// An implementation to read characters from DnDBeyond.
    /// </summary>
    public class CharacterReader : ICharacterReader
    {

        /// <inheritdoc/>
        public Types.CharacterSheet ReadCharacter(JsonDocument characterJson)
        {
            Types.CharacterSheet rc = new();

            JsonCharacter? jsonCharacter;

            jsonCharacter = JsonDeserializer.DeserializeCharacter(characterJson);

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
