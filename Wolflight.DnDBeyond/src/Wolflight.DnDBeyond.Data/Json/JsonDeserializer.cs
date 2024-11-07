using System.Text.Json;

namespace Wolflight.DnDBeyond.Data.Json
{
    public static class JsonDeserializer
    {

        static JsonDeserializer()
        {
            OptionsInstance = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        internal static JsonSerializerOptions OptionsInstance { get; }


        public static JsonCharacter? DeserializeCharacter(JsonDocument characterJson)
        {
            return JsonSerializer.Deserialize<JsonCharacter>(characterJson, OptionsInstance);
        }
    }
}
