namespace Wolflight.DnDBeyond.Data.Json
{
    internal class JsonCharacter
    {
        public long ID { get; set; }

        public bool Success { get; set; }

        public string? Message { get; set; }

        public Character.Data? Data { get; set; }

        public object? Pagination { get; set; }

    }
}
