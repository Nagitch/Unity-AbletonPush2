﻿using System;
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

        public delegate void PadPressedDelegate(Pad pad, float velocity);
        public static Push2.PadPressedDelegate padPressedDelegate { get; set; }

        public delegate void PadReleasedDelegate(Pad pad);
        public static Push2.PadReleasedDelegate padReleasedDelegate { get; set; }
        public delegate void ButtonPressedDelegate(Button button);
        public static Push2.ButtonPressedDelegate buttonPressedDelegate { get; set; }
        public delegate void ButtonReleasedDelegate(Button button);
        public static Push2.ButtonReleasedDelegate buttonReleasedDelegate { get; set; }
        public delegate void EncoderDelegate(RotaryEncoder encoder, float movement);
        public static Push2.EncoderDelegate encoderDelegate { get; set; }
        public delegate void EncoderTouchedDelegate(RotaryEncoder encoder);
        public static Push2.EncoderTouchedDelegate encoderTouchedDelegate { get; set; }
        public delegate void EncoderReleasedDelegate(RotaryEncoder encoder);
        public static Push2.EncoderReleasedDelegate encoderReleasedDelegate { get; set; }
        public delegate void TouchStripTouchedDelegate(TouchStrip touchStrip);
        public static Push2.TouchStripTouchedDelegate touchStripTouchedDelegate { get; set; }
        public delegate void TouchStripReleasedDelegate(TouchStrip touchStrip);
        public static Push2.TouchStripReleasedDelegate touchStripReleasedDelegate { get; set; }

        static Push2()
        {
            // listen MidiJack delegate
            MidiMaster.noteOnDelegate += NoteOn;
            MidiMaster.noteOffDelegate += NoteOff;
            MidiMaster.knobDelegate += Knob;
            // TODO: unregist delegate
        }

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

        static void NoteOn(MidiChannel channel, int note, float velocity)
        {
            Pads.All.ForEach(pad =>
            {
                if (note != pad.number)
                {
                    return;
                }
                padPressedDelegate(pad, velocity);
            });
        }

        static void NoteOff(MidiChannel channel, int note)
        {
            Pads.All.ForEach(pad =>
            {
                if (note != pad.number)
                {
                    return;
                }
                padReleasedDelegate(pad);
            });
        }

        static void Knob(MidiChannel channel, int knobNumber, float knobValue)
        {
        }

    }
}
