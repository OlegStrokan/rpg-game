using System;
using System.Security.Cryptography;

namespace Engine;

public class RandomNumberGenerator
{
    private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

    public static int NumberBetween(int minimumValue, int maximumValue)
    {
        byte[] randonNumber = new byte[1];
        
        _generator.GetBytes(randonNumber);

        double asciiValueOfRandomCharacter = Convert.ToDouble(randonNumber[0]);

        double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

        int range = maximumValue - minimumValue + 1;

        double randomValueInRange = Math.Floor(multiplier * range);

        return (int)(minimumValue + randomValueInRange);
    }
}