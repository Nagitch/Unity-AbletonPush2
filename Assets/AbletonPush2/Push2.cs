using System;
using System.Collections;
using System.Collections.Generic;
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
        public static float GetPad(Pad pad)
        {
            return MidiMaster.GetKey(pad.number);
        }

        public static void SetLED(Part part)
        {
        }
    }
}
