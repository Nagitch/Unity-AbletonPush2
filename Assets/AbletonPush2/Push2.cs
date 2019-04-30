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

        /// <summary>
        /// indicate Push2 device id
        /// </summary>
        /// <param name="midiInDeviceId"></param>
        /// <param name="midiOutDeviceId"></param>
        public static void SetDevice(uint midiInDeviceId, uint midiOutDeviceId)
        {
            SetMidiInDevice(midiInDeviceId);
            SetMidiOutDevice(midiOutDeviceId);
        }

        /// <summary>
        /// indicate Push2 MIDI IN device id
        /// </summary>
        /// <param name="deviceId"></param>
        public static void SetMidiInDevice(uint deviceId)
        {
            MidiInDeviceId = deviceId;
        }

        /// <summary>
        /// indicate Push2 MIDI OUT device id
        /// </summary>
        /// <param name="deviceId"></param>
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

            if (part.message == Message.Note)
            {
                MidiMaster.SendNoteOn(MidiOutDeviceId, channel, part.number, color);
            }
            else if (part.message == Message.CC)
            {
                MidiMaster.SendCC(MidiOutDeviceId, channel, part.number, color);
            }
        }

        public static void SetLED(List<Part> parts, int colorIndex = LED.Color.Mono.Black, int animationControlIndex = LED.Animation.None)
        {
            parts.ForEach(part => SetLED(part, colorIndex, animationControlIndex));
        }
        public static void SetLED(List<Pad> pads, int colorIndex = LED.Color.RGB.Black, int animationControlIndex = LED.Animation.None)
        {
            pads.ForEach(pad => SetLED(pad, colorIndex, animationControlIndex));
        }
        public static void SetLED(List<Button> buttons, int colorIndex = LED.Color.Mono.Black, int animationControlIndex = LED.Animation.None)
        {
            buttons.ForEach(button => SetLED(button, colorIndex, animationControlIndex));
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

            RotaryEncoders.All.ForEach(encoder =>
            {
                if (note != encoder.number)
                {
                    return;
                }
                encoderTouchedDelegate(encoder);
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

            RotaryEncoders.All.ForEach(encoder =>
            {
                if (note != encoder.number)
                {
                    return;
                }
                encoderReleasedDelegate(encoder);
            });
        }

        static void Knob(MidiChannel channel, int knobNumber, float knobValue)
        {
        }

    }
}
