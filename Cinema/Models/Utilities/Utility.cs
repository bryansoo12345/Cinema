using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using System.Reflection;

namespace Cinema.Models.Utilities
{
    public static class Utility
    {
        private static Random random = new Random();

        public const String PleaseContactAdmmin = "Please contact administrator!";
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GenerateString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[length];
            string potentialToken;

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            potentialToken = new String(stringChars);

            return potentialToken;
        }

        public static DateTime SetSecondsToZero(DateTime originalDateTime)
        {
            DateTime adjustedDateTime = new DateTime(
                originalDateTime.Year,
                originalDateTime.Month,
                originalDateTime.Day,
                originalDateTime.Hour,
                originalDateTime.Minute,
                0,  // Set seconds to 0
                0,  
                originalDateTime.Kind 
            );

            return adjustedDateTime;
        }

        public static DateTime RoundToNearestFiveMinutes(DateTime originalDateTime)
        {
            int minutes = originalDateTime.Minute;
            int remainder = minutes % 5;
            int adjustment = remainder < 3 ? -remainder : (5 - remainder);

            // Round the original DateTime to the nearest 5 minutes, seconds set to 0
            DateTime roundedDateTime = new DateTime(
                originalDateTime.Year,
                originalDateTime.Month,
                originalDateTime.Day,
                originalDateTime.Hour,
                minutes + adjustment,
                0, // Set seconds to 0
                originalDateTime.Kind // Preserve the DateTimeKind
            );

            return roundedDateTime;
        }   
    }
}
