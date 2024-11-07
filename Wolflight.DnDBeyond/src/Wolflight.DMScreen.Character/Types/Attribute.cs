namespace Wolflight.DMScreen.Character.Types
{
    public class Attribute(short baseValue)
    {

        /// <summary>
        /// The base value for the attribute.
        /// </summary>
        public short BaseValue { get; set; } = baseValue;

        /// <summary>
        /// A temporary modifier to be applied to the <see cref="BaseValue">.
        /// </summary>
        public short? TemporaryModifier { get; set; }

        /// <summary>
        /// The override value for the attribute.
        /// </summary>
        public short? OverrideValue { get; set; }

        public short CurrentValue
        {
            get
            {
                if (OverrideValue.HasValue)
                {
                    return OverrideValue.Value;
                }
                else
                {
                    return (short)(BaseValue + (TemporaryModifier ?? 0));
                };
            }
        }

        public short CurrentModifier
        {
            get
            {
                return Convert.ToInt16((CurrentValue - 10) / 2);
            }
        }
    }
}
