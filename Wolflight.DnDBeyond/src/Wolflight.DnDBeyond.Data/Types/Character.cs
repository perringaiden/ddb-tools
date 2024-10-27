namespace Wolflight.DnDBeyond.Data.Types
{
    public class Character
    {
        Character()
        {
            Attributes = new Attributes();
        }

        Attributes Attributes { get; }
    }
}
