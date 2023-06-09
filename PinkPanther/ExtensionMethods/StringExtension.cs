﻿namespace PinkPanther
{
    public static class StringExtension
    {
        public static string? Truncate(this string? value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;

            return value.Length >= maxLength ? value[..maxLength] : value;
        }
    }
}
