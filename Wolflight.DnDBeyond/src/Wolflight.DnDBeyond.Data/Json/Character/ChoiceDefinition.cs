namespace Wolflight.DnDBeyond.Data.Json.Character
{
    [DebuggerDisplay("ID: {ID}")]
    public class ChoiceDefinition
    {
        public string? ID { get; set; }

        public IList<ChoiceOption>? Options { get; set; }

    }
}
