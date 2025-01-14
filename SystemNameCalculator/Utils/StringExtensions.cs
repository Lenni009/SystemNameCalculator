﻿using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace SystemNameCalculator.Utils
{
    public static class StringExtensions
    {
        public static string ShortToFormattedHex(this short self, int trunc)
        {
            string s = Convert.ToString(self, 2);
            if (s.Length > 12) s = s[(s.Length - 12)..];
            return Convert.ToInt16(s, 2).ToString($"X{trunc}")[^trunc..];
        }
        public static bool FastContains(this string self, string value)
        {
            return ((self.Length - self.Replace(value, string.Empty).Length) / value.Length) > 0;
        }

        public static string FormatRegionGrfCoords(this ulong self)
        {
            return "0001" + (self & 0xFFFFFFFF).ToString("X").PadLeft(8, '0');
        }

        public static string FormatRegionBoosterCoords(this ulong self)
        {
            return $"{(int)(self & 0xFFF) + 2047:X4}:{(int)((self & 0xFF000000) >> 24) + 127:X4}:{(int)((self & 0xFFF000) >> 12) + 2047:X4}:{(self & 0xFF00000000) >> 32:X4}";
        }

        public static string FormatRegionXCoords(this ulong self)
        {
            return $"X: {RandomExtensions.Sxd(self & 0xFFF, 12)}, Y: {RandomExtensions.Sxd((self & 0xFF000000) >> 24, 8)}, Z: {RandomExtensions.Sxd((self & 0xFFF000) >> 12, 12)}";
        }
    }
}
