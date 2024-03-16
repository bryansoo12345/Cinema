using System.ComponentModel;
using System.Reflection;

namespace Cinema.Models.Utilities
{
    public static class Utility
    {
        private static Random random = new Random();
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
    }
}
