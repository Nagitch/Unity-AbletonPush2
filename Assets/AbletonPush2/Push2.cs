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

        public delegate void PadPressedDelegate(Pad pad, float pressure);
        public static Push2.PadPressedDelegate padPressedDelegate { get; set; }
        public delegate void PadReleasedDelegate(Pad pad);
        public static Push2.PadReleasedDelegate padReleasedDelegate { get; set; }
        public delegate void AfterTouchDelegate(float pressure);
        public static Push2.AfterTouchDelegate afterTouchDelegate { get; set; }
        public delegate void ButtonPressedDelegate(Button button);
        public static Push2.ButtonPressedDelegate buttonPressedDelegate { get; set; }
        public delegate void ButtonReleasedDelegate(Button button);
        public static Push2.ButtonReleasedDelegate buttonReleasedDelegate { get; set; }
        public delegate void EncoderDelegate(RotaryEncoder encoder, float step);
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
            MidiMaster.channelAfterTouchDelegate += ChannelAfterTouch;
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
        // get channel after touch. this API can't indicate what pad is pressed
        public static float GetAfterTouchPressure()
        {
            // TODO: support PolyAfterTouch
            return MidiMaster.GetChannelAfterTouch();
        }

        public static Button GetButton(Button button)
        {
            var b = button.Clone();
            b.pressed = MidiMaster.GetKnob(button.number) == 1.0f;
            return b;
        }

        public static bool GetButtonPressed(Button button)
        {
            return MidiMaster.GetKnob(button.number) == 1.0f;
        }

        public static TouchStrip GetTouchStrip()
        {
            TouchStrip t = _TouchStrip.touchStrip.Clone();
            t.position = MidiMaster.GetBend();
            return t;
        }

        public static float GetTouchStripPosition()
        {
            return MidiMaster.GetBend();
        }

        public static RotaryEncoder GetEncoder(RotaryEncoder encoder)
        {
            RotaryEncoder e = encoder.Clone();
            e.step = PolarEncoderValue(MidiMaster.GetKnob(encoder.number));
            return e;
        }

        public static float GetEncoderStep(RotaryEncoder encoder)
        {
            return PolarEncoderValue(MidiMaster.GetKnob(encoder.number));
        }

        public static bool GetEncoderTouched(RotaryEncoder encoder)
        {
            return MidiMaster.GetKey(encoder.touch.number) == 1.0f;
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
                Pad p = pad.Clone();
                p.pressure = velocity;
                if (padPressedDelegate != null) padPressedDelegate(p, velocity);
            });

            RotaryEncoders.All.ForEach(encoder =>
            {
                if (note != encoder.touch.number)
                {
                    return;
                }
                RotaryEncoder e = encoder.Clone();
                e.touch.touched = true;
                if (encoderTouchedDelegate != null) encoderTouchedDelegate(e);
            });

            if (note == _TouchStrip.touchStrip.number)
            {
                TouchStrip t = _TouchStrip.touchStrip.Clone();
                if (velocity == 1.0f)
                {
                    t.touched = true;
                    if (touchStripTouchedDelegate != null) touchStripTouchedDelegate(t);
                }
                else if (velocity == 0.0f)
                {
                    t.touched = false;
                    if (touchStripReleasedDelegate != null) touchStripReleasedDelegate(t);
                }
            }
        }

        static void NoteOff(MidiChannel channel, int note)
        {
            Pads.All.ForEach(pad =>
            {
                if (note != pad.number)
                {
                    return;
                }
                pad.pressure = 0.0f;
                if (padReleasedDelegate != null) padReleasedDelegate(pad);
            });

            RotaryEncoders.All.ForEach(encoder =>
            {
                if (note != encoder.touch.number)
                {
                    return;
                }
                RotaryEncoder e = encoder.Clone();
                e.touch.touched = false;
                if (encoderReleasedDelegate != null) encoderReleasedDelegate(e);
            });
        }

        static void ChannelAfterTouch(MidiChannel channel, float pressure)
        {
            if (afterTouchDelegate != null) afterTouchDelegate(pressure);
        }

        static void Knob(MidiChannel channel, int knobNumber, float knobValue)
        {
            Buttons.All.ForEach(button =>
            {
                if (button.number != knobNumber) return;
                Button b = button.Clone();

                if (knobValue == 1.0f)
                {
                    if (buttonPressedDelegate != null) buttonPressedDelegate(b);
                }
                else if (knobValue == 0.0f)
                {
                    if (buttonReleasedDelegate != null) buttonReleasedDelegate(b);
                }
            });

            RotaryEncoders.All.ForEach(encoder =>
            {
                if (encoder.number != knobNumber) return;
                RotaryEncoder e = encoder.Clone();
                e.step = PolarEncoderValue(knobValue);
                if (encoderDelegate != null) encoderDelegate(e, e.step);
            });
        }

        // fixes CC knob value 0.0,1.0 to -1.0, 1.0
        private static float PolarEncoderValue(float value)
        {
            return value <= 0.5f ? value * 2.0f : (value - 1.0f) * 2.0f;
        }
    }
}
