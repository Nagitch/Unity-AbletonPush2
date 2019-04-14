using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class MIDIManager : MonoBehaviour {
    private static List<MidiDevice> midiInDevices;
    public static List<MidiDevice> MidiInDevices{ get{ return midiInDevices; } }
    public static int midiInDeviceCount;
    private static List<MidiDevice> midiOutDevices;
    public static List<MidiDevice> MidiOutDevices{ get{ return midiOutDevices; } }
    public static int midiOutDeviceCount;

    public class MidiDevice {
        private uint id;
        public uint Id{ get{ return id; } }

        private string name;
        public string Name{ get{ return name;} }

        public MidiDevice(uint id, string name) {
            this.id = id;
            this.name = name;
        }

        public override string ToString() {
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
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
	}


       #region Native Plugin Interface
        // MIDI IN
        [DllImport("MidiJackPlugin", EntryPoint="MidiJackCountEndpoints")]
        static extern int CountEndpoints();

        [DllImport("MidiJackPlugin", EntryPoint="MidiJackGetEndpointIDAtIndex")]
        static extern uint GetEndpointIdAtIndex(int index);

        [DllImport("MidiJackPlugin")]
        static extern System.IntPtr MidiJackGetEndpointName(uint id);

        static string GetInEndpointName(uint id) {
            return Marshal.PtrToStringAnsi(MidiJackGetEndpointName(id));
        }

        // MIDI OUT
        [DllImport("MidiJackPlugin", EntryPoint="MidiJackCountSendEndpoints")]
        static extern int CountSendEndpoints();

        [DllImport("MidiJackPlugin", EntryPoint="MidiJackGetSendEndpointIDAtIndex")]
        static extern uint GetSendEndpointIdAtIndex(int index);

        [DllImport("MidiJackPlugin")]
        static extern System.IntPtr MidiJackGetSendEndpointName(uint id);

        static string GetSendEndpointName(uint id) {
            return Marshal.PtrToStringAnsi(MidiJackGetSendEndpointName(id));
        }

        #endregion

}
