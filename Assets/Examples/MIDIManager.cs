﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using AbletonPush2;

public class MIDIManager : MonoBehaviour
{
    private static List<MidiDevice> midiInDevices;
    public static List<MidiDevice> MidiInDevices { get { return midiInDevices; } }
    public static int midiInDeviceCount;
    public static int midiInDeviceCountBefore;
    private static List<MidiDevice> midiOutDevices;
    public static List<MidiDevice> MidiOutDevices { get { return midiOutDevices; } }
    public static int midiOutDeviceCount;
    public static int midiOutDeviceCountBefore;

    public class MidiDevice
    {
        private uint id;
        public uint Id { get { return id; } }

        private string name;
        public string Name { get { return name; } }

        public MidiDevice(uint id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return id.ToString("X8") + ": " + name;
        }
    };


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        midiInDevices = new List<MidiDevice>();
        midiOutDevices = new List<MidiDevice>();
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        var endpointCountIn = CountEndpoints();
        midiInDeviceCount = endpointCountIn;
        midiInDevices.Clear();
        var endpointCountSend = CountSendEndpoints();
        midiOutDeviceCount = endpointCountSend;
        midiOutDevices.Clear();

        for (var i = 0; i < endpointCountIn; i++)
        {
            var id = GetEndpointIdAtIndex(i);
            var name = GetInEndpointName(id);
            MidiDevice mi = new MidiDevice(id, name);
            midiInDevices.Add(mi);
        }
        for (var i = 0; i < endpointCountSend; i++)
        {
            var id = GetSendEndpointIdAtIndex(i);
            var name = GetSendEndpointName(id);
            MidiDevice mo = new MidiDevice(id, name);
            midiOutDevices.Add(mo);
        }

        // indicate Push2
        if (midiOutDeviceCountBefore != midiOutDeviceCount)
        {
            for (var i = 0; i < midiOutDeviceCount; i++)
            {
                var option = MIDIManager.MidiOutDevices[i];
                if (option.Name.IndexOf("Ableton Push 2") == 0)
                {
                    // push2OptionIndex = i;
                }
            }

        }
        midiInDeviceCountBefore = midiInDeviceCount;
        midiOutDeviceCountBefore = midiOutDeviceCount;
    }

    public static void SetPush2MIDIOutDevice(int deviceIndex)
    {
        Push2.SetMidiOutDevice(midiOutDevices[deviceIndex].Id);
    }

    public static void WakeupPush2()
    {
        Push2.SetLED(Pads.All, LED.Color.RGB.Black);
        Push2.SetLED(Buttons.All, LED.Color.Mono.Black);
        Push2.SetLED(Pads.All, LED.Color.RGB.LightGray);
        Push2.SetLED(Buttons.All, LED.Color.Mono.DarkGray);
        Push2.SetLED(Buttons.OnePerAll, LED.Color.RGB.Green);
        Push2.SetLED(Buttons.Record, LED.Color.RGB.Red);
        Push2.SetLED(Buttons.Play, LED.Color.RGB.Black);
        Push2.SetLED(Buttons.Play, LED.Color.RGB.Green, LED.Animation.PulsingQuarter);
        Push2.SetLED(Buttons.UpperRowAll, LED.Color.RGB.LightBlue);
        Push2.SetLED(Buttons.LowerRowAll, LED.Color.RGB.Yellow);
    }

    #region Native Plugin Interface
    // MIDI IN
    [DllImport("MidiJackPlugin", EntryPoint = "MidiJackCountEndpoints")]
    static extern int CountEndpoints();

    [DllImport("MidiJackPlugin", EntryPoint = "MidiJackGetEndpointIDAtIndex")]
    static extern uint GetEndpointIdAtIndex(int index);

    [DllImport("MidiJackPlugin")]
    static extern System.IntPtr MidiJackGetEndpointName(uint id);

    static string GetInEndpointName(uint id)
    {
        return Marshal.PtrToStringAnsi(MidiJackGetEndpointName(id));
    }

    // MIDI OUT
    [DllImport("MidiJackPlugin", EntryPoint = "MidiJackCountSendEndpoints")]
    static extern int CountSendEndpoints();

    [DllImport("MidiJackPlugin", EntryPoint = "MidiJackGetSendEndpointIDAtIndex")]
    static extern uint GetSendEndpointIdAtIndex(int index);

    [DllImport("MidiJackPlugin")]
    static extern System.IntPtr MidiJackGetSendEndpointName(uint id);

    static string GetSendEndpointName(uint id)
    {
        return Marshal.PtrToStringAnsi(MidiJackGetSendEndpointName(id));
    }

    #endregion

}
