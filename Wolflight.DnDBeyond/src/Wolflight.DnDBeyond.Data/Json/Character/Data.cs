using System.Text.Json;
namespace Wolflight.DnDBeyond.Data.Json.Character
{
    internal class Data
    {
        public long ID { get; set; }

        public long UserID { get; set; }

        public string? UserName { get; set; }

        public bool IsAssignedToPlayer { get; set; }

        public Uri? ReadOnlyUrl { get; set; }

        public JsonElement Decorations { get; set; }

        public string? Name { get; set; }

        public IEnumerable<Stat>? Stats { get; set; }

        public IEnumerable<BonusStat>? BonusStats { get; set; }

    }
}
