using System.Text.Json;
namespace Wolflight.DnDBeyond.Data.Json.Character
{
    public class Data
    {
        public long ID { get; set; }

        public long UserID { get; set; }

        public string? UserName { get; set; }

        public bool IsAssignedToPlayer { get; set; }

        public Uri? ReadOnlyUrl { get; set; }

        public JsonElement Decorations { get; set; }

        public string? Name { get; set; }

        public IList<Stat>? Stats { get; set; }

        public IList<AdditionalStat>? BonusStats { get; set; }

        public IList<AdditionalStat>? OverrideStats { get; set; }

        public ChoicesSet? Choices { get; set; }
    }
}
