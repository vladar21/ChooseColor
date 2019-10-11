using System;

namespace ChooseColor.Models
{
    internal sealed class Color : IEquatable<Color>
    {
        private readonly byte alpha;
        private readonly byte blue;
        private readonly byte green;
        private readonly byte red;

        public Color(byte red, byte green, byte blue) :
            this(alpha: 255, red, green, blue)
        {
        }

        public Color(byte alpha, byte red, byte green, byte blue)
        {
            this.alpha = alpha;
            this.blue = blue;
            this.green = green;
            this.red = red;
        }

        public byte Alpha => alpha;

        public byte Blue => blue;

        public byte Green => green;

        public string Name => $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";

        public byte Red => red;

        public bool Equals(Color other)
        {
            return !(other is null) &&
                alpha.Equals(other.alpha) &&
                blue.Equals(other.blue) &&
                green.Equals(other.green) &&
                red.Equals(other.red);
        }

    }
}
