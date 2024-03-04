namespace Markem_Imaje_9450
{
    public static class Fonts
    {
        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_32x22 = new(){ Height = 32, Dimensions = [0x01, 0x00] };

        /// <summary>
        /// Latin font Height: 5 | Width: 6
        /// </summary>
        public static readonly Font Latin_5x6   = new(){ Height = 5, Dimensions = [0x01, 0x1A] };

        /// <summary>
        /// Latin font Height: 7 | Width: 6
        /// </summary>
        public static readonly Font Latin_7x6   = new(){ Height = 7, Dimensions = [0x01, 0x1B] };

        /// <summary>
        /// Latin font Height: 9 | Width: 6
        /// </summary>
        public static readonly Font Latin_9x6   = new(){ Height = 9, Dimensions = [0x01, 0x1C] };

        /// <summary>
        /// Latin font Height: 11 | Width: 8
        /// </summary>
        public static readonly Font Latin_11x8  = new(){ Height = 11, Dimensions = [0x01, 0x1D] };

        /// <summary>
        /// Latin font Height: 16 | Width: 12
        /// </summary>
        public static readonly Font Latin_16x12 = new(){ Height = 16, Dimensions = [0x01, 0x1E] };

        /// <summary>
        /// Latin font Height: 24 | Width: 21
        /// </summary>
        public static readonly Font Latin_24x21 = new(){ Height = 24, Dimensions = [0x01, 0x1F] };
    }

    public class Font
    {
        /// <summary>
        /// The height of the character
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The dimension that the printer expecting
        /// </summary>
        public byte[] Dimensions { get; set; }
    }
}
