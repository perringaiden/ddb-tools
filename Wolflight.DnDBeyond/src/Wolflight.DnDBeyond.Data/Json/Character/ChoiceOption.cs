namespace Wolflight.DnDBeyond.Data.Json.Character
{
    [DebuggerDisplay("ID: {ID} Label: {Label}")]
    public class ChoiceOption
    {
        public long ID { get; set; }

        public string? Label { get; set; }

        public string? Description { get; set; }

        public long? SourceID { get; set; }
    }
}
