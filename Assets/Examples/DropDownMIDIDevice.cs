using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbletonPush2;

public class DropDownMIDIDevice : MonoBehaviour
{
    public enum ListAs
    {
        MIDIInDevices,
        MIDIOutDevices,
    }

    private int deviceCountBefore = 0;

    public ListAs listAs = ListAs.MIDIInDevices;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RefreshMIDIDeviceList();
    }

    public void RefreshMIDIDeviceList()
    {
        Dropdown dd = GetComponent<Dropdown>();
        dd.ClearOptions();

        int? push2OptionIndex = null;
        int deviceCount = listAs == ListAs.MIDIInDevices ? MIDIManager.midiInDeviceCount : MIDIManager.midiOutDeviceCount;
        for (var i = 0; i < deviceCount; i++)
        {
            var option = listAs == ListAs.MIDIInDevices ? MIDIManager.MidiInDevices[i] : MIDIManager.MidiOutDevices[i];
            dd.options.Add(new Dropdown.OptionData(option.ToString()));
            if (option.Name.IndexOf("Ableton Push 2") == 0)
            {
                push2OptionIndex = i;
            }
        }

        dd.RefreshShownValue();

        if (deviceCount != deviceCountBefore && push2OptionIndex != null)
        {
            dd.value = (int)push2OptionIndex;
            MIDIManager.WakeupPush2();
        }

        deviceCountBefore = deviceCount;
    }

    public void OnValueChanged(Dropdown dropdown)
    {
        MIDIManager.SetPush2MIDIOutDevice(dropdown.value);
    }
}
