namespace Wolflight.DMScreen.Character.Types
{
    public class Attributes
    {
        public Attributes()
        {
            Strength = new Attribute(0);
            Dexterity = new Attribute(0);
            Constitution = new Attribute(0);
            Intelligence = new Attribute(0);
            Wisdom = new Attribute(0);
            Charisma = new Attribute(0);
        }

        /// <summary>
        /// The character's Strength attribute.
        /// </summary>
        public Attribute Strength { get; }
        /// <summary>
        /// The character's Dexterity attribute.
        /// </summary>
        public Attribute Dexterity { get; }

        /// <summary>
        /// The character's Constitution attribute.
        /// </summary>
        public Attribute Constitution { get; }

        /// <summary>
        /// The character's Intelligence attribute.
        /// </summary>
        public Attribute Intelligence { get; }

        /// <summary>
        /// The character's Wisdom attribute.
        /// </summary>
        public Attribute Wisdom { get; }

        /// <summary>
        /// The character's Charisma attribute.
        /// </summary>
        public Attribute Charisma { get; }
    }
}
