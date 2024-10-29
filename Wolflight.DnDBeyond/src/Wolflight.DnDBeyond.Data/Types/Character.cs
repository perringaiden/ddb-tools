namespace Wolflight.DnDBeyond.Data.Types
{
    public class Character
    {
        public Character()
        {
            Attributes = new Attributes();
        }

        public Attributes Attributes { get; }
    }
}
