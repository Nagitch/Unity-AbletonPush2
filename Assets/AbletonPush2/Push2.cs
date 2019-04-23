using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

namespace AbletonPush2
{
    public static class Push2
    {
        public static uint MidiInDeviceId;
        public static uint MidiOutDeviceId;

        public static void SetDevice(uint midiInDeviceId, uint midiOutDeviceId)
        {
            MidiInDeviceId = midiInDeviceId;
            MidiOutDeviceId = midiOutDeviceId;
        }

        public static void SetMidiInDevice(uint deviceId)
        {
            MidiInDeviceId = deviceId;
        }
        public static void SetMidiOutDevice(uint deviceId)
        {
            MidiOutDeviceId = deviceId;
        }

        public static Pad GetPad(Pad pad)
        {
            Pad p = pad.Clone();
            p.pressure = MidiMaster.GetKey(pad.number);
            return p;
        }
        public static float GetPadPressure(Pad pad)
        {
            return MidiMaster.GetKey(pad.number);
        }
        public static float GetButton(Button button)
        {
            return MidiMaster.GetKnob(button.number);
        }
        public static float GetTouchStrip()
        {
            return MidiMaster.GetKey(TouchStrip.number);
        }
        public static float GetEncoder(RotaryEncoder encoder)
        {
            return MidiMaster.GetKnob(encoder.number);
        }

        public static void SetLED(Part part, int colorIndex = LED.Color.Mono.Black, int animationControlIndex = LED.Animation.None)
        {
            var channel = (MidiJack.MidiChannel)animationControlIndex;
            var color = (float)colorIndex / (float)127;
            MidiMaster.SendNoteOn(MidiOutDeviceId, channel, part.number, color);
        }

        public static void SetLED(List<Part> parts, int colorIndex = LED.Color.Mono.Black, int animationControlIndex = LED.Animation.None)
        {
            parts.ForEach(part => SetLED(part, colorIndex, animationControlIndex));
        }
    }
}
