namespace Extensions
{
    public static class MathExtensions
    {
        public static int Wrap(this int input, int min, int max)
        {
            if (input < min)
            {
                return max - (min - input) % (max - min);
            }

            return min + (input - min) % (max - min);
        }
    }
}