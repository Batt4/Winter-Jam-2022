using System;

namespace WinterJam2022.Scripts.Verses.Domain
{
    public static class ProbabilityHelper
    {
        public static readonly Random Random = new Random();

        public static bool IsBetween(int lower, int higher, int value) => (value >= lower) && (value <= higher);
        
        public static bool IsSuccessful(int probability)
        {
            if (probability >= 100)
                return true;
            if (probability <= 0)
                return false;
            return probability <= Random.Next(1, 100);
        }
    }
}