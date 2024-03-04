namespace Markem_Imaje_9450
{
    public static class Fonts
    {
        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_32x22 = new(){ Height = 0x32, Dimensions = [0x01, 0x00] };

        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_5x6   = new(){ Height = 0x05, Dimensions = [0x01, 0x1A] };

        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_7x6   = new(){ Height = 0x07, Dimensions = [0x01, 0x1B] };

        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_9x6   = new(){ Height = 0x09, Dimensions = [0x01, 0x1C] };

        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_11x8  = new(){ Height = 0x11, Dimensions = [0x01, 0x1D] };

        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_16x12 = new(){ Height = 0x16, Dimensions = [0x01, 0x1E] };

        /// <summary>
        /// Latin font Height: 32 | Width: 22
        /// </summary>
        public static readonly Font Latin_24x21 = new(){ Height = 0x24, Dimensions = [0x01, 0x1F] };
    }

    public class Font
    {
        /// <summary>
        /// The height of the character
        /// </summary>
        public byte Height { get; set; }

        /// <summary>
        /// The dimension that the printer expecting
        /// </summary>
        public byte[] Dimensions { get; set; }
    }
}