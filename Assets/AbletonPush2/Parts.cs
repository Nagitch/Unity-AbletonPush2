﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AbletonPush2
{

    public static class Parts
    {
        public enum Message
        {
            Note,
            CC,
            PichBend,
        }

        public class Part
        {
            public string name = null;
            public int number;
            public Message message;
            public Boolean? color = null;
        }

        public class Pad : Part { }
        public static class Pads
        {
            public static Pad S8T1 = new Pad { number = 36, message = Message.Note, color = true, name = "Pad S8 T1", };
            public static Pad S8T2 = new Pad { number = 37, message = Message.Note, color = true, name = "Pad S8 T2", };
            public static Pad S8T3 = new Pad { number = 38, message = Message.Note, color = true, name = "Pad S8 T3", };
            public static Pad S8T4 = new Pad { number = 39, message = Message.Note, color = true, name = "Pad S8 T4", };
            public static Pad S8T5 = new Pad { number = 40, message = Message.Note, color = true, name = "Pad S8 T5", };
            public static Pad S8T6 = new Pad { number = 41, message = Message.Note, color = true, name = "Pad S8 T6", };
            public static Pad S8T7 = new Pad { number = 42, message = Message.Note, color = true, name = "Pad S8 T7", };
            public static Pad S8T8 = new Pad { number = 43, message = Message.Note, color = true, name = "Pad S8 T8", };
            public static Pad S7T1 = new Pad { number = 44, message = Message.Note, color = true, name = "Pad S7 T1", };
            public static Pad S7T2 = new Pad { number = 45, message = Message.Note, color = true, name = "Pad S7 T2", };
            public static Pad S7T3 = new Pad { number = 46, message = Message.Note, color = true, name = "Pad S7 T3", };
            public static Pad S7T4 = new Pad { number = 47, message = Message.Note, color = true, name = "Pad S7 T4", };
            public static Pad S7T5 = new Pad { number = 48, message = Message.Note, color = true, name = "Pad S7 T5", };
            public static Pad S7T6 = new Pad { number = 49, message = Message.Note, color = true, name = "Pad S7 T6", };
            public static Pad S7T7 = new Pad { number = 50, message = Message.Note, color = true, name = "Pad S7 T7", };
            public static Pad S7T8 = new Pad { number = 51, message = Message.Note, color = true, name = "Pad S7 T8", };
            public static Pad S6T1 = new Pad { number = 52, message = Message.Note, color = true, name = "Pad S6 T1", };
            public static Pad S6T2 = new Pad { number = 53, message = Message.Note, color = true, name = "Pad S6 T2", };
            public static Pad S6T3 = new Pad { number = 54, message = Message.Note, color = true, name = "Pad S6 T3", };
            public static Pad S6T4 = new Pad { number = 55, message = Message.Note, color = true, name = "Pad S6 T4", };
            public static Pad S6T5 = new Pad { number = 56, message = Message.Note, color = true, name = "Pad S6 T5", };
            public static Pad S6T6 = new Pad { number = 57, message = Message.Note, color = true, name = "Pad S6 T6", };
            public static Pad S6T7 = new Pad { number = 58, message = Message.Note, color = true, name = "Pad S6 T7", };
            public static Pad S6T8 = new Pad { number = 59, message = Message.Note, color = true, name = "Pad S6 T8", };
            public static Pad S5T1 = new Pad { number = 60, message = Message.Note, color = true, name = "Pad S5 T1", };
            public static Pad S5T2 = new Pad { number = 61, message = Message.Note, color = true, name = "Pad S5 T2", };
            public static Pad S5T3 = new Pad { number = 62, message = Message.Note, color = true, name = "Pad S5 T3", };
            public static Pad S5T4 = new Pad { number = 63, message = Message.Note, color = true, name = "Pad S5 T4", };
            public static Pad S5T5 = new Pad { number = 64, message = Message.Note, color = true, name = "Pad S5 T5", };
            public static Pad S5T6 = new Pad { number = 65, message = Message.Note, color = true, name = "Pad S5 T6", };
            public static Pad S5T7 = new Pad { number = 66, message = Message.Note, color = true, name = "Pad S5 T7", };
            public static Pad S5T8 = new Pad { number = 67, message = Message.Note, color = true, name = "Pad S5 T8", };
            public static Pad S4T1 = new Pad { number = 68, message = Message.Note, color = true, name = "Pad S4 T1", };
            public static Pad S4T2 = new Pad { number = 69, message = Message.Note, color = true, name = "Pad S4 T2", };
            public static Pad S4T3 = new Pad { number = 70, message = Message.Note, color = true, name = "Pad S4 T3", };
            public static Pad S4T4 = new Pad { number = 71, message = Message.Note, color = true, name = "Pad S4 T4", };
            public static Pad S4T5 = new Pad { number = 72, message = Message.Note, color = true, name = "Pad S4 T5", };
            public static Pad S4T6 = new Pad { number = 73, message = Message.Note, color = true, name = "Pad S4 T6", };
            public static Pad S4T7 = new Pad { number = 74, message = Message.Note, color = true, name = "Pad S4 T7", };
            public static Pad S4T8 = new Pad { number = 75, message = Message.Note, color = true, name = "Pad S4 T8", };
            public static Pad S3T1 = new Pad { number = 76, message = Message.Note, color = true, name = "Pad S3 T1", };
            public static Pad S3T2 = new Pad { number = 77, message = Message.Note, color = true, name = "Pad S3 T2", };
            public static Pad S3T3 = new Pad { number = 78, message = Message.Note, color = true, name = "Pad S3 T3", };
            public static Pad S3T4 = new Pad { number = 79, message = Message.Note, color = true, name = "Pad S3 T4", };
            public static Pad S3T5 = new Pad { number = 80, message = Message.Note, color = true, name = "Pad S3 T5", };
            public static Pad S3T6 = new Pad { number = 81, message = Message.Note, color = true, name = "Pad S3 T6", };
            public static Pad S3T7 = new Pad { number = 82, message = Message.Note, color = true, name = "Pad S3 T7", };
            public static Pad S3T8 = new Pad { number = 83, message = Message.Note, color = true, name = "Pad S3 T8", };
            public static Pad S2T1 = new Pad { number = 84, message = Message.Note, color = true, name = "Pad S2 T1", };
            public static Pad S2T2 = new Pad { number = 85, message = Message.Note, color = true, name = "Pad S2 T2", };
            public static Pad S2T3 = new Pad { number = 86, message = Message.Note, color = true, name = "Pad S2 T3", };
            public static Pad S2T4 = new Pad { number = 87, message = Message.Note, color = true, name = "Pad S2 T4", };
            public static Pad S2T5 = new Pad { number = 88, message = Message.Note, color = true, name = "Pad S2 T5", };
            public static Pad S2T6 = new Pad { number = 89, message = Message.Note, color = true, name = "Pad S2 T6", };
            public static Pad S2T7 = new Pad { number = 90, message = Message.Note, color = true, name = "Pad S2 T7", };
            public static Pad S2T8 = new Pad { number = 91, message = Message.Note, color = true, name = "Pad S2 T8", };
            public static Pad S1T1 = new Pad { number = 92, message = Message.Note, color = true, name = "Pad S1 T1", };
            public static Pad S1T2 = new Pad { number = 93, message = Message.Note, color = true, name = "Pad S1 T2", };
            public static Pad S1T3 = new Pad { number = 94, message = Message.Note, color = true, name = "Pad S1 T3", };
            public static Pad S1T4 = new Pad { number = 95, message = Message.Note, color = true, name = "Pad S1 T4", };
            public static Pad S1T5 = new Pad { number = 96, message = Message.Note, color = true, name = "Pad S1 T5", };
            public static Pad S1T6 = new Pad { number = 97, message = Message.Note, color = true, name = "Pad S1 T6", };
            public static Pad S1T7 = new Pad { number = 98, message = Message.Note, color = true, name = "Pad S1 T7", };
            public static Pad S1T8 = new Pad { number = 99, message = Message.Note, color = true, name = "Pad S1 T8", };
        };

        public class Button : Part { }
        public static class Buttons
        {
            public static Button TapTempo = new Button { number = 3, message = Message.CC, color = false, name = "Tap Tempo" };
            public static Button Metronome = new Button { number = 9, message = Message.CC, color = false, name = "Metronome" };
            public static Button Delete = new Button { number = 118, message = Message.CC, color = false, name = "Delete" };
            public static Button Undo = new Button { number = 119, message = Message.CC, color = false, name = "Undo" };
            public static Button Mute = new Button { number = 60, message = Message.CC, color = true, name = "Mute" };
            public static Button Solo = new Button { number = 61, message = Message.CC, color = true, name = "Solo" };
            public static Button Stop = new Button { number = 29, message = Message.CC, color = true, name = "Stop" };
            public static Button Convert = new Button { number = 35, message = Message.CC, color = false, name = "Convert" };
            public static Button DoubleLoop = new Button { number = 117, message = Message.CC, color = false, name = "Double Loop" };
            public static Button Quantize = new Button { number = 116, message = Message.CC, color = false, name = "Quantize" };
            public static Button Duplicate = new Button { number = 88, message = Message.CC, color = false, name = "Duplicate" };
            public static Button New = new Button { number = 87, message = Message.CC, color = false, name = "New" };
            public static Button FixedLength = new Button { number = 90, message = Message.CC, color = false, name = "Fixed Length" };
            public static Button Automate = new Button { number = 89, message = Message.CC, color = true, name = "Automate" };
            public static Button Record = new Button { number = 86, message = Message.CC, color = true, name = "Record" };
            public static Button Play = new Button { number = 85, message = Message.CC, color = true, name = "Play" };
            public static Button UpperRow1 = new Button { number = 102, message = Message.CC, color = true, name = "Upper Row 1" };
            public static Button UpperRow2 = new Button { number = 103, message = Message.CC, color = true, name = "Upper Row 2" };
            public static Button UpperRow3 = new Button { number = 104, message = Message.CC, color = true, name = "Upper Row 3" };
            public static Button UpperRow4 = new Button { number = 105, message = Message.CC, color = true, name = "Upper Row 4" };
            public static Button UpperRow5 = new Button { number = 106, message = Message.CC, color = true, name = "Upper Row 5" };
            public static Button UpperRow6 = new Button { number = 107, message = Message.CC, color = true, name = "Upper Row 6" };
            public static Button UpperRow7 = new Button { number = 108, message = Message.CC, color = true, name = "Upper Row 7" };
            public static Button UpperRow8 = new Button { number = 109, message = Message.CC, color = true, name = "Upper Row 8" };
            public static Button LowerRow1 = new Button { number = 20, message = Message.CC, color = true, name = "Lower Row 1" };
            public static Button LowerRow2 = new Button { number = 21, message = Message.CC, color = true, name = "Lower Row 2" };
            public static Button LowerRow3 = new Button { number = 22, message = Message.CC, color = true, name = "Lower Row 3" };
            public static Button LowerRow4 = new Button { number = 23, message = Message.CC, color = true, name = "Lower Row 4" };
            public static Button LowerRow5 = new Button { number = 24, message = Message.CC, color = true, name = "Lower Row 5" };
            public static Button LowerRow6 = new Button { number = 25, message = Message.CC, color = true, name = "Lower Row 6" };
            public static Button LowerRow7 = new Button { number = 26, message = Message.CC, color = true, name = "Lower Row 7" };
            public static Button LowerRow8 = new Button { number = 27, message = Message.CC, color = true, name = "Lower Row 8" };
            public static Button OnePer32t = new Button { number = 43, message = Message.CC, color = true, name = "1/32t" };
            public static Button OnePer32 = new Button { number = 42, message = Message.CC, color = true, name = "1/32" };
            public static Button OnePer16t = new Button { number = 41, message = Message.CC, color = true, name = "1/16t" };
            public static Button OnePer16 = new Button { number = 40, message = Message.CC, color = true, name = "1/16" };
            public static Button OnePer8t = new Button { number = 39, message = Message.CC, color = true, name = "1/8t" };
            public static Button OnePer8 = new Button { number = 38, message = Message.CC, color = true, name = "1/8" };
            public static Button OnePer4t = new Button { number = 37, message = Message.CC, color = true, name = "1/4t" };
            public static Button OnePer4 = new Button { number = 36, message = Message.CC, color = true, name = "1/4" };
            public static Button Setup = new Button { number = 30, message = Message.CC, color = false, name = "Setup" };
            public static Button User = new Button { number = 59, message = Message.CC, color = false, name = "User" };
            public static Button AddDevice = new Button { number = 52, message = Message.CC, color = false, name = "Add Device" };
            public static Button AddTrack = new Button { number = 53, message = Message.CC, color = false, name = "Add Track" };
            public static Button Device = new Button { number = 110, message = Message.CC, color = false, name = "Device" };
            public static Button Mix = new Button { number = 112, message = Message.CC, color = false, name = "Mix" };
            public static Button Browse = new Button { number = 111, message = Message.CC, color = false, name = "Browse" };
            public static Button Clip = new Button { number = 113, message = Message.CC, color = false, name = "Clip" };
            public static Button Master = new Button { number = 28, message = Message.CC, color = false, name = "Master" };
            public static Button Up = new Button { number = 46, message = Message.CC, color = false, name = "Up" };
            public static Button Down = new Button { number = 47, message = Message.CC, color = false, name = "Down" };
            public static Button Left = new Button { number = 44, message = Message.CC, color = false, name = "Left" };
            public static Button Right = new Button { number = 45, message = Message.CC, color = false, name = "Right" };
            public static Button Repeat = new Button { number = 56, message = Message.CC, color = false, name = "Repeat" };
            public static Button Accent = new Button { number = 57, message = Message.CC, color = false, name = "Accent" };
            public static Button Scale = new Button { number = 58, message = Message.CC, color = false, name = "Scale" };
            public static Button Layout = new Button { number = 31, message = Message.CC, color = false, name = "Layout" };
            public static Button Note = new Button { number = 50, message = Message.CC, color = false, name = "Note" };
            public static Button Session = new Button { number = 51, message = Message.CC, color = false, name = "Session" };
            public static Button OctaveUp = new Button { number = 55, message = Message.CC, color = false, name = "Octave Up" };
            public static Button OctaveDown = new Button { number = 54, message = Message.CC, color = false, name = "Octave Down" };
            public static Button PageLeft = new Button { number = 62, message = Message.CC, color = false, name = "Page Left" };
            public static Button PageRight = new Button { number = 63, message = Message.CC, color = false, name = "Page Right" };
            public static Button Shift = new Button { number = 49, message = Message.CC, color = false, name = "Shift" };
            public static Button Select = new Button { number = 48, message = Message.CC, color = false, name = "Select" };
        }

        public class RotaryEncoder : Part
        {
            public int position;
            public Touch touch;
        }

        public class Touch : Part { }
        public static class RotaryEncoders
        {
            public static RotaryEncoder TempoEncoder = new RotaryEncoder { number = 14, message = Message.CC, position = 1, name = "Tempo Encoder", touch = new Touch { number = 10, message = Message.CC } };
            public static RotaryEncoder SwingEncoder = new RotaryEncoder { number = 15, message = Message.CC, position = 2, name = "Swing Encoder", touch = new Touch { number = 9, message = Message.CC } };
            public static RotaryEncoder Track1Encoder = new RotaryEncoder { number = 71, message = Message.CC, position = 3, name = "Track1 Encoder", touch = new Touch { number = 0, message = Message.CC } };
            public static RotaryEncoder Track2Encoder = new RotaryEncoder { number = 72, message = Message.CC, position = 4, name = "Track2 Encoder", touch = new Touch { number = 1, message = Message.CC } };
            public static RotaryEncoder Track3Encoder = new RotaryEncoder { number = 73, message = Message.CC, position = 5, name = "Track3 Encoder", touch = new Touch { number = 2, message = Message.CC } };
            public static RotaryEncoder Track4Encoder = new RotaryEncoder { number = 74, message = Message.CC, position = 6, name = "Track4 Encoder", touch = new Touch { number = 3, message = Message.CC } };
            public static RotaryEncoder Track5Encoder = new RotaryEncoder { number = 75, message = Message.CC, position = 7, name = "Track5 Encoder", touch = new Touch { number = 4, message = Message.CC } };
            public static RotaryEncoder Track6Encoder = new RotaryEncoder { number = 76, message = Message.CC, position = 8, name = "Track6 Encoder", touch = new Touch { number = 5, message = Message.CC } };
            public static RotaryEncoder Track7Encoder = new RotaryEncoder { number = 77, message = Message.CC, position = 9, name = "Track7 Encoder", touch = new Touch { number = 6, message = Message.CC } };
            public static RotaryEncoder Track8Encoder = new RotaryEncoder { number = 78, message = Message.CC, position = 10, name = "Track8 Encoder", touch = new Touch { number = 7, message = Message.CC } };
            public static RotaryEncoder MasterEncoder = new RotaryEncoder { number = 79, message = Message.CC, position = 11, name = "Master Encoder", touch = new Touch { number = 8, message = Message.CC } };
        }

        public class _Slider : Part { }
        public static _Slider Slider = new _Slider { number = 12, message = Message.PichBend, name = "Slider", };
    }
}
