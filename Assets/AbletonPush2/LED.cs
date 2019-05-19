using System.Collections;
using System.Collections.Generic;

namespace AbletonPush2
{

    /// <summary>
    /// LED preset color definitions
    /// value as color index
    /// </summary>
    public class LED
    {
        public static class Color
        {
            public static class Mono
            {
                public const int Black = 0;
                public const int DarkGray = 16;
                public const int LightGray = 48;
                public const int White = 127;
            }

            public static class RGB
            {
                public const int Black = 0;
                public const int Yellow = 70;
                public const int LightBlue = 95;
                public const int White = 122;
                public const int LightGray = 123;
                public const int DarkGray = 124;
                public const int Blue = 125;
                public const int Green = 126;
                public const int Red = 127;
            }
        }

        /// <summary>
        /// Animation type definitions
        /// value as channel number for LED animation control
        /// </summary>
        public static class Animation
        {
            public const int None = 0;
            public const int OneShot24th = 1;
            public const int OneShot16th = 2;
            public const int OneShot8th = 3;
            public const int OneShotQuarter = 4;
            public const int OneShotHalf = 5;
            public const int Pulsing24th = 6;
            public const int Pulsing12th = 7;
            public const int Pulsing8th = 8;
            public const int PulsingQuarter = 9;
            public const int PulsingHalf = 10;
            public const int Blinking24th = 11;
            public const int Blinking16th = 12;
            public const int Blinking8th = 13;
            public const int BlinkingQuarter = 14;
            public const int BlinkingHalf = 15;
        }
    }
}
