using System;
using System.Collections.Generic;

namespace WinterJam2022.Scripts.Verses.Domain
{
    public static class ListExtensions
    {
        static readonly Random random = new Random();
        
        public static T PickOne<T>(this List<T> source) => source[random.Next(source.Count)];
    }
}